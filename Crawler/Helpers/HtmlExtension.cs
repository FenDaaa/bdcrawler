// <copyright file="UrlExtensions.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.Helpers
{
    using HtmlAgilityPack;
    using System.Linq;
    using System.Text.RegularExpressions;
    public static class HtmlExtension
    {
        public static string TrimContent(this string content)
        {
            string trimLabel = Regex.Replace(content, "<.+?>", string.Empty, RegexOptions.IgnoreCase).Trim();
            string trimSpace = Regex.Replace(trimLabel, @"\s{2,}", " ", RegexOptions.IgnoreCase);
            return trimSpace;
        }

        public static HtmlNode TrimScript(this HtmlNode node)
        {
            var scripts = node?.SelectNodes("//script");
            scripts?.ToList().ForEach(script => script.Remove());
            return node;
        }

        public static string TrimTable(this string content)
        {
            string trimTable = Regex.Replace(content, "\t", string.Empty, RegexOptions.IgnoreCase).Trim();
            return trimTable;
        }
    }
}
