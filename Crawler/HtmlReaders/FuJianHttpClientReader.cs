// <copyright file="HtmlAgilityPackReader.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.HtmlReaders
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Net.Http;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Web;
    using Crawler.Helpers;

    public class FuJianHttpClientReader : HttpClientReader
    {
        private Dictionary<string, string> relatedRule = new Dictionary<string, string>() { { "page", "1" }, { "pageSize", "1" }, { "postTitle", "" }, { "postType", "/" } };

        public override string GetHtml(string url)
        {
            try
            {
                var response = GetResponse(url);
                if (response.Content.Headers.ContentType != null && response.Content.Headers.ContentType.MediaType != "text/xml" && response.Content.Headers.ContentType.MediaType != "text/html")
                {
                    return "[Not a html page.]";
                }

                var html = response.Content.ReadAsStringAsync().Result;

                if (response.Content.Headers.ContentType != null && response.Content.Headers.ContentType.CharSet == null && CharSetRegex.IsMatch(html))
                {
                    string charset = CharSetRegex.Match(html).Groups[1].Value;
                    response.Content.Headers.ContentType.CharSet = charset.IndexOf("GB", StringComparison.OrdinalIgnoreCase) > -1 ? "GBK" : charset;
                    html = response.Content.ReadAsStringAsync().Result;
                }

                if(response.Content.Headers.ContentEncoding.ToString().ToLower().Contains("gzip"))
                {
                    using (GZipStream stream = new GZipStream(response.Content.ReadAsStreamAsync().Result, CompressionMode.Decompress))
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            html = reader.ReadToEnd();
                        }
                    }
                }

                return HttpUtility.HtmlDecode(html);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        private HttpResponseMessage GetResponse(string url)
        {
            if (url.IndexOf("postType=") > 0)
            {
                string site = url.Substring(url.IndexOf("postType="), url.IndexOf("&page=") - url.IndexOf("postType=")).Replace("postType=", string.Empty);
                int page = int.Parse(url.Substring(url.IndexOf("page="), url.Length - url.IndexOf("page=")).Replace("page=", string.Empty));
                FuJianPostParam param = new FuJianPostParam() { Page = page, PageSize = 20, PostTitle = string.Empty, PostType = site };
                DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(FuJianPostParam));
                StringContent content = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    jsonSer.WriteObject(ms, param);
                    ms.Position = 0;
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        content = new StringContent(sr.ReadToEnd(), Encoding.UTF8, "application/json");
                    }
                }
                return this.client.PostAsync(url, content).Result;
            }
            else
            {
                return this.client.GetAsync(url).Result;
            }
        }
    }

    [DataContract]
    public class FuJianPostParam
    {
        [DataMember(Name = "page")]
        public int Page { get; set; }

        [DataMember(Name = "pageSize")]
        public int PageSize { get; set; }

        [DataMember(Name = "postTitle")]
        public string PostTitle { get; set; }

        [DataMember(Name = "postType")]
        public string PostType { get; set; }
    }
}
