// <copyright file="HtmlAgilityPackReader.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.HtmlReaders
{
    using Crawler.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Web;

    public class JiangSuHttpClientReader: HttpClientReader
    {
        private Dictionary<string, string> law = new Dictionary<string, string>() { { "appid", "1" }, { "col", "1" }, { "columnid", "57242" }, { "path", "/" }, { "permissiontype", "0" }, { "sourceContentType", "3" }, { "unitid", "231190" }, { "webid", "67" }, { "webname", "江苏省人力资源和社会保障厅" } };

        private Dictionary<string, string> hotLaw = new Dictionary<string, string>() { { "appid", "1" }, { "col", "1" }, { "columnid", "44576" }, { "path", "/" }, { "permissiontype", "0" }, { "sourceContentType", "1" }, { "unitid", "204014" }, { "webid", "67" }, { "webname", "江苏省人力资源和社会保障厅" } };

        private Dictionary<string, string> normativeFile = new Dictionary<string, string>() { { "appid", "1" }, { "col", "1" }, { "columnid", "1202376" }, { "path", "/" }, { "permissiontype", "0" }, { "sourceContentType", "1" }, { "unitid", "3935857" }, { "webid", "1855" }, { "webname", "浙江省卫生和计划生育委员会门户网站" } };

        private Dictionary<string, string> lawFile = new Dictionary<string, string>() { { "appid", "1" }, { "col", "1" }, { "columnid", "1202453" }, { "path", "/" }, { "permissiontype", "0" }, { "sourceContentType", "1" }, { "unitid", "3936510" }, { "webid", "1855" }, { "webname", "浙江省卫生和计划生育委员会门户网站" } };

        private Dictionary<string, string> policyRead = new Dictionary<string, string>() { { "appid", "1" }, { "col", "1" }, { "columnid", "1202375" }, { "path", "/" }, { "permissiontype", "0" }, { "sourceContentType", "1" }, { "unitid", "3935857" }, { "webid", "1855" }, { "webname", "浙江省卫生和计划生育委员会门户网站" } };

        private Dictionary<string, string> combinedService = new Dictionary<string, string>() { { "appid", "1" }, { "col", "1" }, { "columnid", "7270" }, { "path", "/" }, { "permissiontype", "0" }, { "sourceContentType", "9" }, { "unitid", "223142" }, { "webid", "31" }, { "webname", "江苏省卫生和计划生育委员会" } };

        private Dictionary<string, string> relatedRule = new Dictionary<string, string>() { { "appid", "1" }, { "col", "1" }, { "columnid", "93" }, { "path", "/" }, { "permissiontype", "0" }, { "sourceContentType", "1" }, { "unitid", "572" }, { "webid", "1" }, { "webname", "陕西省卫生和计划生育委员会" } };

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

                return HttpUtility.HtmlDecode(html);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        private HttpResponseMessage GetResponse(string url)
        {
            if (url.IndexOf("site=") > 0)
            {
                var request = new HttpRequestMessage { RequestUri = new Uri(url), Method = HttpMethod.Post };
                string site = url.Substring(url.IndexOf("site="), url.Length - url.IndexOf("site=")).Replace("site=", string.Empty);
                request.Content = new FormUrlEncodedContent(GetDictionary(site));
                return this.client.SendAsync(request).Result;
            }
            else
            {
                return this.client.GetAsync(url).Result;
            }
        }

        private Dictionary<string, string> GetDictionary(string site)
        {
            switch (site)
            {
                case "law":
                    return law;
                case "hotLaw":
                    return hotLaw;
                case "normativeFile":
                    return normativeFile;
                case "lawFile":
                    return lawFile;
                case "combinedService":
                    return combinedService;
                case "relatedRule":
                    return relatedRule;
                default:
                    return policyRead;
            }
        }
    }
}
