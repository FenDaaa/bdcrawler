// <copyright file="HenanHrPageParser.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.PageParsers
{
    using System;
    using Crawler.Helpers;
    using Crawler.HtmlReaders;
    using DataAccess.Models;
    using HtmlAgilityPack;
    using MultiLogger;

    public class HenanHrPageParser : RegexPageParser
    {
        public HenanHrPageParser(SiteParameter siteParameter, IHtmlReader htmlReader) : base(siteParameter, htmlReader)
        {
        }

        public override Article GetArticleDetails(Article article)
        {
            try
            {
                string content = this.HtmlReader.GetHtml(article.Url);
                if (string.IsNullOrWhiteSpace(content))
                {
                    Logging.WriteEntry(this, LogType.Warning, $"{article.Url} is not reachable.");
                    return article;
                }

                Logging.WriteEntry(this, LogType.Information, $"Getting details {article.Url}");

                var document = new HtmlDocument();
                document.LoadHtml(content);
                var contentNode = document.DocumentNode.SelectSingleNode(SiteParameter.ContentPattern);
                article.Content = contentNode?.TrimScript().OuterHtml;

                var iframeDocument = document.DocumentNode.SelectSingleNode("//iframe");
                var iframeUrl = iframeDocument.Attributes["src"].Value.ToAbsoluteUrl(article.Url);
                var iframeHtml = this.HtmlReader.GetHtml(iframeUrl);
                document.LoadHtml(iframeHtml);

                article.Category = HenanHrPageParser.MatchedValue(this.SiteParameter.CategoryPattern, document);
                article.CrawledDate = DateTime.Now;
                article.IndexCode = HenanHrPageParser.MatchedValue(this.SiteParameter.IndexCodePattern, document);
                article.IssueCode = HenanHrPageParser.MatchedValue(this.SiteParameter.IssueCodePattern, document);
                article.Keyword = HenanHrPageParser.MatchedValue(this.SiteParameter.KeywordPattern, document);
                article.PublishAgency = HenanHrPageParser.MatchedValue(this.SiteParameter.PublishAgencyPattern, document);

                string publishDate = MatchedValue(this.SiteParameter.PublishDatePattern, document);
                if (!string.IsNullOrWhiteSpace(publishDate))
                {
                    article.PublishDate = DateTime.Parse(publishDate);
                }

                return article;
            }
            catch (Exception ex)
            {
                this.ErrorHandler.Invoke(article.Url, ex);
                Logging.WriteEntry(this, LogType.Error, $"Fetching {article.Url} error.", ex);
                return null;
            }
        }
    }
}
