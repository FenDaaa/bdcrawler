// <copyright file="HtmlAgilityPackReader.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.HtmlReaders
{
    using HtmlAgilityPack;
    using System;
    using System.Web;

    public class HtmlAgilityPackReader : HttpClientReader
    {
        private HtmlWeb web = new HtmlWeb();

        public override string GetHtml(string url)
        {
            try
            {
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
