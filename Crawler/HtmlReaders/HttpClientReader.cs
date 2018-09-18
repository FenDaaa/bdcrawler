// <copyright file="HttpClientReader.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.HtmlReaders
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text.RegularExpressions;
    using System.Web;
    using Crawler.Helpers;
    using MultiLogger;

    public class HttpClientReader : IHtmlReader
    {
        protected static readonly Regex CharSetRegex = new Regex("<meta.*charset=(?:\")?(.+?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        protected HttpClient client = new HttpClient();
        private string fileExtension = "(.*?\\.\\w{3,4})";

        public virtual string GetHtml(string url)
        {
            try
            {
                var response = this.client.GetAsync(url).Result;
                if (response.Content.Headers.ContentType != null && response.Content.Headers.ContentType.MediaType != "text/html" && response.Content.Headers.ContentType.MediaType != "application/json")
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

                return HttpUtility.HtmlDecode(html);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public byte[] Download(string url, out string fileName)
        {
            Logging.WriteEntry(this, LogType.Information, $"Start to download {url}.");
            fileName = string.Empty;
            try
            {
                var response = this.client.GetAsync(url).Result;
                if (response.StatusCode.GetHashCode() == 200)
                {
                    if (response.Content.Headers.ContentDisposition != null)
                    {
                        fileName = response.Content.Headers.ContentDisposition.FileName.Trim('"');
                    }
                    else
                    {
                        fileName = url.Split('/').Last();
                        if (!Regex.IsMatch(fileName, fileExtension))
                        {
                            if (Regex.IsMatch(response.Content.Headers.ToString(), fileExtension))
                            {
                                fileName = Regex.Match(response.Content.Headers.ToString(), fileExtension).Groups[1].Value;
                            }
                        }
                        else
                        {
                            fileName = Regex.Match(fileName, fileExtension).Groups[1].Value;
                        }
                    }
                    using (Stream htmlStream = response.Content.ReadAsStreamAsync().Result)
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        htmlStream.CopyTo(memoryStream);
                        var result = memoryStream.ToArray();
                        memoryStream.Close();
                        return result;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Logging.WriteEntry(this, LogType.Error, $"Downloading {url} error.", ex);
                return null;
            }
        }
    }
}
