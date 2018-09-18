// <copyright file="GeneralSiteCrawler.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.SiteCrawler
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Crawler.DataServices;
    using Crawler.HtmlReaders;
    using Crawler.ItemReaders;
    using Crawler.PageParsers;
    using Crawler.PageReaders;
    using DataAccess;
    using DataAccess.Models;
    using MultiLogger;

    public class GeneralSiteCrawler : ISiteCrawler
    {
        private IPageReader pageReader;
        private IPageParser pageParser;
        private IDataService dataService;

        public GeneralSiteCrawler(IPageReader pageReader, IPageParser pageParser, IDataService dataService)
        {
            this.pageReader = pageReader ?? throw new ArgumentNullException(nameof(pageReader));
            this.pageParser = pageParser ?? throw new ArgumentNullException(nameof(pageParser));
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            this.pageParser.SetErrorHandler((url, exception) =>
                this.dataService.AddLog(new CrawlerLog
                {
                    Url = url,
                    LogTime = DateTime.Now,
                    Message = exception.Message
                }));
        }

        public GeneralSiteCrawler(SiteParameter siteParameter)
        {
            this.dataService = new DbDataService(CrawlerDbHelper.GetContext());
            IItemReader itemReader = new RegexItemReader(siteParameter);

            IHtmlReader htmlReader = new HttpClientReader();

            this.pageReader = new SequentialPageReader(siteParameter, htmlReader, itemReader);
            this.pageParser = new RegexPageParser(siteParameter, htmlReader);
            this.pageParser.SetErrorHandler((url, exception) => 
                this.dataService.AddLog(new CrawlerLog
                {
                    Url = url,
                    LogTime = DateTime.Now,
                    Message = exception.Message
                }));
        }

        public void Crawl(SiteParameter siteParameter)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            ArticleMonitor monitor = new ArticleMonitor() { StartTime = DateTime.Now, SiteName = siteParameter.SiteName };
            if(!string.IsNullOrWhiteSpace(siteParameter.StartUrl))
            {
                monitor.SiteUrl = siteParameter.StartUrl;
            }
            else
            {
                monitor.SiteUrl = string.Format(siteParameter.UrlPattern, siteParameter.StartNumber, siteParameter.PageStepNumber);
            }
            IEnumerable<Article> articles = this.pageReader.GetArticals().ToArray();
 
            articles = articles.Select(article => this.pageParser.GetArticleDetails(article)).ToArray();

            this.dataService.AddOrUpdateArticles(articles, monitor);

            int attachmentCount = 0;

            foreach (var article in articles)
            {
                var attatchments = this.pageParser.GetAttachments(article);
                attachmentCount += attatchments?.Count() ?? 0;

                this.dataService.AddOrUpdateArticleAttachments(attatchments);
            }
            this.dataService.AddOrUpdateArticleMontior(monitor);
            string info = string.Format("{0} articles crawled, {1} attachments crawled.", articles.Count(), attachmentCount);
            Logging.WriteEntry(this, LogType.Information, info);

            Logging.WriteEntry(this, LogType.Information, $"{stopwatch.Elapsed} elapsed.");
        }
    }
}
