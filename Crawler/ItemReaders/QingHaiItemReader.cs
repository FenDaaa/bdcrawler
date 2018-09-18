// <copyright file="QingHaiItemReader.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.ItemReaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Crawler.Helpers;
    using DataAccess.Models;

    public class QingHaiItemReader : IItemReader
    {
        private SiteParameter siteParameter;
        private Regex pattern;
        private string baseUrl = "http://www.qhhrss.gov.cn/qhrstweb/zcfg/zcfginfo.action?rid=";

        public QingHaiItemReader(SiteParameter siteParameter)
        {
            this.siteParameter = siteParameter ?? throw new ArgumentNullException(nameof(siteParameter));
            this.pattern = new Regex(siteParameter.ItemPattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);
        }

        public IEnumerable<Article> GetArticles(string html, string pageUrl)
        {
            MatchCollection matches = this.pattern.Matches(html);
            IEnumerable<Article> articles = matches
                .Cast<Match>()
                .Select(match =>
                {
                    DateTime? publishDate = null;
                    if (this.siteParameter.DatePosition > 0)
                    {
                        publishDate = DateTime.Parse(match.Groups[siteParameter.DatePosition].Value);
                    }

                    return new Article
                    {
                        IsShow = 0,
                        IsCenter = this.siteParameter.IsCenter == null ? 0 : Convert.ToInt32(this.siteParameter.IsCenter),
                        Url = string.Format("{0}{1}", baseUrl, match.Groups[this.siteParameter.UrlPosition].Value),
                        SiteName = this.siteParameter.SiteName,
                        Title = match.Groups[this.siteParameter.CaptionPosition].Value.TrimContent(),
                        PublishDate = publishDate,
                    };
                });

            return articles;
        }
    }
}
