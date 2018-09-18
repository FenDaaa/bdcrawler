// <copyright file="SequentialPageReader.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.PageReaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Crawler.HtmlReaders;
    using Crawler.ItemReaders;
    using DataAccess.Compares;
    using DataAccess.Models;
    using MultiLogger;

    public class SequentialPageReader : IPageReader
    {
        private SiteParameter siteParameter;
        private IHtmlReader htmlReader;
        private IItemReader itemReader;
        private int pageNumber = -1;

        public SequentialPageReader(SiteParameter siteParameter, IHtmlReader htmlReader, IItemReader itemReader)
        {
            this.siteParameter = siteParameter ?? throw new ArgumentNullException(nameof(siteParameter));
            this.htmlReader = htmlReader ?? throw new ArgumentNullException(nameof(htmlReader));
            this.itemReader = itemReader ?? throw new ArgumentNullException(nameof(itemReader));
            this.pageNumber = this.siteParameter.StartNumber;
        }

        public IEnumerable<Article> GetArticals()
        {
            IEnumerable<Article> articles = null;
            List<string> urls = new List<string>();

            if (!string.IsNullOrWhiteSpace(this.siteParameter.StartUrl))
            {
                Logging.WriteEntry(this, LogType.Information, $"Parsing {this.siteParameter.StartUrl}");
                string html = null;
                try
                {
                    html = this.htmlReader.GetHtml(this.siteParameter.StartUrl);
                }
                catch (Exception ex)
                {
                    Logging.WriteEntry(this, LogType.Error, $"Request {this.siteParameter.StartUrl} error.", ex);
                }

                if (string.IsNullOrWhiteSpace(html))
                {
                    yield break;
                }

                articles = this.itemReader
                    .GetArticles(html, this.siteParameter.StartUrl).Distinct(new ArticleCompare())
                    .Where(article => !urls.Contains(article.Url));

                foreach (var article in articles)
                {
                    urls.Add(article.Url);
                    Logging.WriteEntry(this, LogType.Information, $"Getting {article.Url}");
                    yield return article;
                }
            }

            do
            {
                string url = string.Format(this.siteParameter.UrlPattern, this.pageNumber);
                this.pageNumber += this.siteParameter.PageStepNumber ?? 1;
                Logging.WriteEntry(this, LogType.Information, $"Parsing {url}");

                string html = null;
                try
                {
                    html = this.htmlReader.GetHtml(url);
                }
                catch (Exception ex)
                {
                    Logging.WriteEntry(this, LogType.Error, $"Request {url} error.", ex);
                }

                if (string.IsNullOrWhiteSpace(html))
                {
                    yield break;
                }

                articles = this.itemReader
                    .GetArticles(html, url).Distinct(new ArticleCompare())
                    .Where(article => !urls.Contains(article.Url)).ToArray();

                foreach (var article in articles)
                {
                    if (urls.Contains(article.Url))
                    {
                        yield break;
                    }

                    urls.Add(article.Url);
                    Logging.WriteEntry(this, LogType.Information, $"Getting {article.Url}");
                    yield return article;
                }
            }
            while (articles.Count() > 0);
        }
    }
}
