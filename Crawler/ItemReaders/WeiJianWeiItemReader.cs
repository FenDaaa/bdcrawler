// <copyright file="WeiJianWeiItemReader.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.ItemReaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;
    using Crawler.Helpers;
    using DataAccess.Models;

    public class WeiJianWeiItemReader : IItemReader
    {
        private SiteParameter siteParameter;
        private Regex pattern;
        private string baseUrl = "http://www.nhfpc.gov.cn/xxgk/pages/viewdocument.jsp?";

        public WeiJianWeiItemReader(SiteParameter siteParameter)
        {
            this.siteParameter = siteParameter ?? throw new ArgumentNullException(nameof(siteParameter));
            this.pattern = new Regex(siteParameter.ItemPattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);
        }

        public IEnumerable<Article> GetArticles(string html, string pageUrl)
        {
            MatchCollection matches = this.pattern.Matches(html);
            IEnumerable<Article> articles = matches
                .Cast<Match>()
                .Select(match => GetUrl(match));

            return articles;
        }

        public Article GetUrl(Match match)
        {
            Article article = new Article();
            article.IsShow = 0;
            article.IsCenter = this.siteParameter.IsCenter == null ? 0 : Convert.ToInt32(this.siteParameter.IsCenter);
            string matchHtml = match.Groups[0].Value;
            article.PublishDate = DateTime.Parse(match.Groups[this.siteParameter.DatePosition].Value);
            article.SiteName = this.siteParameter.SiteName;
            MatchCollection matches = Regex.Matches(matchHtml, @"<INPUT.+?>");
            StringBuilder sb = new StringBuilder(this.baseUrl);
            sb.Append("indexNum=");
            if (matches[0].Groups[0].Value.Contains("value"))
            {
                sb.Append(Regex.Match(matches[0].Groups[0].Value, @"value=(?:"")?(.+?)(?:"")? ").Groups[1].Value);
            }

            sb.Append("&dispatchDate=");
            if (matches[1].Groups[0].Value.Contains("value"))
            {
                sb.Append(Regex.Match(matches[1].Groups[0].Value, @"value=(.+?) ").Groups[1].Value);
            }

            sb.Append("&wenhao=");
            if (matches[2].Groups[0].Value.Contains("value"))
            {
                sb.Append(Regex.Match(matches[2].Groups[0].Value, @"value=(?:"")?(.+?)(?:"")? ").Groups[1].Value);
            }

            sb.Append("&topictype=");
            if (matches[3].Groups[0].Value.Contains("value"))
            {
                sb.Append(Regex.Match(matches[3].Groups[0].Value, @"value=(.+?) ").Groups[1].Value);
            }

            sb.Append("&publishedOrg=");
            if (matches[4].Groups[0].Value.Contains("value"))
            {
                sb.Append(Regex.Match(matches[4].Groups[0].Value, @"value=(?:"")?(.+?)(?:"")? ").Groups[1].Value);
            }

            sb.Append("&topic=");
            if (matches[5].Groups[0].Value.Contains("value"))
            {
                sb.Append(Regex.Match(matches[5].Groups[0].Value, @"value=(?:"")?(.+?)(?:"")? ").Groups[1].Value);
            }

            sb.Append("&staticUrl=");
            if (matches[6].Groups[0].Value.Contains("value"))
            {
                sb.Append(Regex.Match(matches[6].Groups[0].Value, @"value=(.+?) ").Groups[1].Value);
            }

            sb.Append("&title=");
            if (matches[7].Groups[0].Value.Contains("value"))
            {
                string titleHtml = HttpUtility.HtmlDecode(matches[7].Groups[0].Value);
                string title = Regex.Match(titleHtml.TrimTable(), @"value=(?:"")?(.+?)(?:"")? ").Groups[1].Value;
                sb.Append(title);
                article.Title = title;
            }

            sb.Append("&manuscriptId=");
            if (matches[8].Groups[0].Value.Contains("value"))
            {
                sb.Append(Regex.Match(matches[8].Groups[0].Value, @"value=(.+?) ").Groups[1].Value);
            }

            article.Url = sb.ToString();
            return article;
        }
    }
}
