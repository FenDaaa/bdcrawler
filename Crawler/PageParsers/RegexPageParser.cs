// <copyright file="RegexPageParser.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.PageParsers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Crawler.Helpers;
    using Crawler.HtmlReaders;
    using DataAccess.Models;
    using HtmlAgilityPack;
    using MultiLogger;

    public class RegexPageParser : IPageParser
    {
        public RegexPageParser(SiteParameter siteParameter, IHtmlReader htmlReader)
        {
            this.SiteParameter = siteParameter ?? throw new ArgumentNullException(nameof(siteParameter));
            this.HtmlReader = htmlReader ?? throw new ArgumentNullException(nameof(htmlReader));
        }

        protected SiteParameter SiteParameter { get; }

        protected IHtmlReader HtmlReader { get; }

        protected Action<string, Exception> ErrorHandler { get; set; } = null;

        public virtual Article GetArticleDetails(Article article)
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

                article.Category = MatchedValue(this.SiteParameter.CategoryPattern, document);
                article.CrawledDate = DateTime.Now;
                article.IndexCode = MatchedValue(this.SiteParameter.IndexCodePattern, document);
                article.IssueCode = MatchedValue(this.SiteParameter.IssueCodePattern, document);
                article.Keyword = MatchedValue(this.SiteParameter.KeywordPattern, document);
                article.PublishAgency = MatchedValue(this.SiteParameter.PublishAgencyPattern, document);

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

        public virtual IEnumerable<ArticleAttachment> GetAttachments(Article article)
        {
            if (article == null || string.IsNullOrWhiteSpace(article.Content) || string.IsNullOrWhiteSpace(this.SiteParameter.AttachmentPattern) || !Regex.IsMatch(article.Content, this.SiteParameter.AttachmentPattern, RegexOptions.IgnoreCase))
            {
                return null;
            }

            Logging.WriteEntry(this, LogType.Information, $"Wait downloading attachment from {article.Url}");
            var match = Regex.Match(article.Content, this.SiteParameter.AttachmentPattern, RegexOptions.IgnoreCase);
            var attachments = match.Groups.Cast<Group>().Skip(1)
                .Where(group => !string.IsNullOrWhiteSpace(group.Value))
                .Select(group => new ArticleAttachment
                {
                    ArticleUrl = article.Url,
                    SourceUrl = group.Value.ToAbsoluteUrl(article.Url)
                })
                .Select(attachment =>
                {
                    string fileName = string.Empty;
                    attachment.FileContent = this.HtmlReader.Download(attachment.SourceUrl, out fileName);
                    attachment.AttachmentName = fileName;
                    attachment.CrawledDate = DateTime.Now;
                    return attachment;
                }).ToArray();

            return attachments;
        }

        public virtual void SetErrorHandler(Action<string, Exception> errorHandler)
        {
            this.ErrorHandler = errorHandler;
        }

        protected static string MatchedValue(string pattern, HtmlDocument document)
        {
            if (string.IsNullOrWhiteSpace(pattern) || string.IsNullOrWhiteSpace(document.Text))
            {
                return null;
            }

            var result = string.Empty;
            if (!pattern.StartsWith("//"))
            {
                return Regex.Match(document.Text, pattern)?.Groups[1].Value.TrimContent();
            }
            else
            {
                var contentNode = document.DocumentNode.SelectSingleNode(pattern);
                return contentNode?.TrimScript().OuterHtml.TrimContent();
            }
        }
    }
}
