// <copyright file="QualityPageReader.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.PageReaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Crawler.Helpers;
    using Crawler.HtmlReaders;
    using Crawler.ItemReaders;
    using DataAccess.Compares;
    using DataAccess.Models;
    using MultiLogger;

    public class QualityPageReader : IPageReader
    {
        private SiteParameter siteParameter;
        private IHtmlReader htmlReader;
        private IItemReader itemReader;
        private int pageNumber = -1;
        private Regex iframePattern = new Regex("<iframe src=\"(.+?)\".+?id=\"iframeid\">", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private string quality2012 = "var title='\\s+?<a href=\"(.+?)\".+?title=\"(.+?)\">.+?<\\/a>';\\s+?var.+?;\\s+?var crtime='(.+?)'";
        private string quality2013 = "<td.+?><span.+?>.<\\/span>\\s+?<a href=\"(.+?)\".+?>(.+?)<\\/a>\\s?<\\/td>\\s+?<td.+?><font.+?><\\s+?(.+?)>\\s+?<\\/font><\\/td>";

        public QualityPageReader(SiteParameter siteParameter, IHtmlReader htmlReader, IItemReader itemReader)
        {
            this.siteParameter = siteParameter ?? throw new ArgumentNullException(nameof(siteParameter));
            this.htmlReader = htmlReader ?? throw new ArgumentNullException(nameof(htmlReader));
            this.itemReader = itemReader ?? throw new ArgumentNullException(nameof(itemReader));
            this.pageNumber = this.siteParameter.StartNumber;
        }

        public IEnumerable<Article> GetArticals()
        {
            int start = 1999;
            int end = DateTime.Now.Year;

            for (int year = start; year <= end; year++)
            {
                IEnumerable<Article> articles = null;
                List<string> urls = new List<string>();
                if (this.siteParameter.SiteName.Contains("总局令"))
                {
                    if (year < 2011)
                    {
                        continue;
                    }
                    else if (year >= 2011 && year < 2013)
                    {
                        this.siteParameter.ItemPattern = quality2012;
                    }
                    else
                    {
                        this.siteParameter.ItemPattern = quality2013;
                    }
                    this.itemReader = new RegexItemReader(this.siteParameter);
                }

                if (!string.IsNullOrWhiteSpace(this.siteParameter.StartUrl))
                {
                    Logging.WriteEntry(this, LogType.Information, $"Parsing {this.siteParameter.StartUrl}");

                    string url = this.siteParameter.StartUrl.Replace("year", year.ToString());

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

                    if (this.iframePattern.IsMatch(html))
                    {
                        var iframeUrl = this.iframePattern.Match(html).Groups[1].Value;
                        url = iframeUrl.ToAbsoluteUrl(url);
                        html = this.htmlReader.GetHtml(url);
                    }

                    articles = this.itemReader
                        .GetArticles(html, url).Distinct(new ArticleCompare())
                        .Where(article => !urls.Contains(article.Url));
                    
                    foreach (var article in articles)
                    {
                        urls.Add(article.Url);
                        Logging.WriteEntry(this, LogType.Information, $"Getting {article.Url}");
                        yield return article;
                    }
                }

                this.pageNumber = this.siteParameter.StartNumber;
                do
                {
                    string url = string.Format(this.siteParameter.UrlPattern, this.pageNumber);
                    url = url.Replace("year", year.ToString()); 

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

                    if (this.iframePattern.IsMatch(html))
                    {
                        var iframeUrl = this.iframePattern.Match(html).Groups[1].Value;
                        url = iframeUrl.ToAbsoluteUrl(url);
                        html = this.htmlReader.GetHtml(url);
                    }

                    articles = this.itemReader
                        .GetArticles(html, url).Distinct(new ArticleCompare())
                        .Where(article => !urls.Contains(article.Url));

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
}
