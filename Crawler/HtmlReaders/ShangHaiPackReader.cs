// <copyright file="HtmlAgilityPackReader.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.HtmlReaders
{
    using HtmlAgilityPack;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class ShangHaiPackReader : HttpClientReader
    {
        private HtmlWeb web = new HtmlWeb();
        private List<string> maps = new List<string>() { ".xls", ".pdf", ".doc", ".xlsx", ".docx" };

        public override string GetHtml(string url)
        {
            try
            {
                string match = maps.FirstOrDefault(s => url.ToLower().Contains(s));
                if (!string.IsNullOrWhiteSpace(match))
                {
                    return string.Empty;
                }

                var html = this.web.LoadFromBrowser(url);
                return HttpUtility.HtmlDecode(html.ParsedText);
            }
            catch (UriFormatException)
            {
                return null;
            }
        }
    }
}
