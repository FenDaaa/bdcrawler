// <copyright file="ShanXiPageReader.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.PageReaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Crawler.HtmlReaders;
    using Crawler.ItemReaders;
    using DataAccess.Compares;
    using DataAccess.Models;
    using MultiLogger;

    public class ShanXiPageReader: IPageReader
    {
        private SiteParameter siteParameter;
        private IHtmlReader htmlReader;
        private IItemReader itemReader;
        private int pageNumber = -1;
        private List<Tuple<string, string, int>> maps = new List<Tuple<string, string, int>>() {
            new Tuple<string, string, int>("甘肃计生委-最新信息", "<span>共<em>(.+?)</em>条", 10),
            new Tuple<string, string, int>("山西人力资源和社会保障厅_信息公开", "共\\s+?(.+?)\\s+?条", 17),
            new Tuple<string, string, int>("中华卫健委-信息公开", "共\\s+?(.+?)\\s+?条", 5)
        };


        public ShanXiPageReader(SiteParameter siteParameter, IHtmlReader htmlReader, IItemReader itemReader)
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
            int total = 0;
            Tuple<string, string, int> current = maps.FirstOrDefault(f => f.Item1 == this.siteParameter.SiteName);

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

                total = Convert.ToInt32(Regex.Match(html, current.Item2).Groups[1].Value);
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

                if (Regex.IsMatch(html, current.Item2))
                {
                    total = Convert.ToInt32(Regex.Match(html, current.Item2).Groups[1].Value);
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
            while ((this.pageNumber - 1) * current.Item3 < total);
        }
    }
}
