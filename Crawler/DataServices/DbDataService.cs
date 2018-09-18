// <copyright file="DbDataService.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.DataServices
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.IO;
    using System.Linq;
    using DataAccess;
    using DataAccess.Models;
    using MultiLogger;

    public class DbDataService : IDataService
    {
        private CrawlerDbContext context;

        public DbDataService(CrawlerDbContext context)
        {
            this.context = context;

            // this.context.Database.Log = log => File.AppendAllText(@"d:\crawler.sql", log + Environment.NewLine);
        }

        public void AddOrUpdateArticles(IEnumerable<Article> articles, ArticleMonitor monitor)
        {
            monitor.HistoryCount = this.context.Articles.Where(s => s.SiteName == monitor.SiteName)?.Count() ?? 0;
            monitor.HistoryPublishDate = this.context.Articles.Where(a => a.SiteName == monitor.SiteName && a.PublishDate != null)?.Max(a => a.PublishDate);
            monitor.CurrentCount = articles?.Count() ?? 0;
            monitor.CurrentPublishDate = articles?.Where(a => a != null && a.PublishDate != null)?.Max(a => a.PublishDate);
            if (articles == null)
            {
                return;
            }

            articles = articles
                .Where(article => !string.IsNullOrWhiteSpace(article?.Content));

            var groups = articles
                .GroupBy(article => article.Url);

            var duplicated = groups
                .Where(group => group.Count() > 1)
                .Select(group => group.First());

            foreach (var article in duplicated)
            {
                Logging.WriteEntry(this, LogType.Warning, $"Article {article.Url} is duplicated.");
            }

            articles = groups
                .Select(group => group.First());

            var keys = articles.Select(article => article.Url);

            var existKeys = this.context
                .Articles
                .AsNoTracking()
                .Where(article => keys.Contains(article.Url))
                .Select(article => article.Url)
                .ToArray();

            foreach (var article in articles)
            {
                this.context.Articles.Attach(article);
                this.context.Entry(article).State = existKeys.Contains(article.Url) ? EntityState.Modified : EntityState.Added;
                this.SaveChanges();
                this.context.Entry(article).State = EntityState.Detached;
            }
        }

        public void AddOrUpdateArticleAttachments(IEnumerable<ArticleAttachment> attachments)
        {
            if (attachments == null)
            {
                return;
            }

            attachments = attachments
                .Where(attachment => attachment?.FileContent?.Length > 0);

            var groups = attachments
                .GroupBy(attachment => attachment.SourceUrl);

            var duplicated = groups
                .Where(group => group.Count() > 1)
                .Select(group => group.First());

            foreach (var attachment in duplicated)
            {
                Logging.WriteEntry(this, LogType.Warning, $"Attachment {attachment.SourceUrl} is duplicated.");
            }

            attachments = groups
                .Select(group => group.First());

            var keys = attachments.Select(attachment => attachment.SourceUrl);

            var existKeys = this.context
                .ArticleAttachments
                .AsNoTracking()
                .Where(attachment => keys.Contains(attachment.SourceUrl))
                .Select(attachment => attachment.SourceUrl)
                .ToArray();

            foreach (var attachment in attachments)
            {
                this.context.ArticleAttachments.Attach(attachment);
                this.context.Entry(attachment).State = existKeys.Contains(attachment.SourceUrl) ? EntityState.Modified : EntityState.Added;
                this.SaveChanges();
                this.context.Entry(attachment).State = EntityState.Detached;
            }
        }

        public void AddOrUpdateArticleMontior(ArticleMonitor monitor)
        {
            if (monitor.CurrentCount == 0)
            {
                monitor.Status = 0;//抓取异常
            }

            if (monitor.CurrentCount > monitor.HistoryCount || monitor.CurrentPublishDate > monitor.HistoryPublishDate)
            {
                monitor.Status = 2;//有更新
            }

            if (monitor.CurrentCount <= monitor.HistoryCount)
            {
                monitor.Status = 1;//暂无更新
            }

            ArticleMonitor history = this.context.ArticleMonitors.FirstOrDefault(f => f.SiteName == monitor.SiteName);
            if (history == null)
            {
                history = new ArticleMonitor();
                history.SiteName = monitor.SiteName;
                history.SiteUrl = monitor.SiteUrl;
            }
            history.Status = monitor.Status;
            history.StartTime = monitor.StartTime;
            history.EndTime = DateTime.Now;
            this.context.ArticleMonitors.Attach(history);
            this.context.Entry(history).State = history.Id < 1 ? EntityState.Added : EntityState.Modified;
            this.SaveChanges();
            this.context.Entry(history).State = EntityState.Detached;
        }

        public void AddLog(CrawlerLog log)
        {
            this.context.CrawlerLogs.Add(log);
            this.SaveChanges();
            this.context.Entry(log).State = EntityState.Detached;
        }

        public void SaveChanges()
        {
            try
            {
                this.context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityError in ex.EntityValidationErrors)
                {
                    Logging.WriteEntry(this, LogType.Error, $"Entity of type '{entityError.Entry.Entity.GetType().Name}' in state '{entityError.Entry.State}' has the following validation errors:");

                    foreach (var validationError in entityError.ValidationErrors)
                    {
                        Logging.WriteEntry(this, LogType.Error, $"- Property: '{validationError.PropertyName}', Error: '{validationError.ErrorMessage}'");
                    }
                }

                throw;
            }
        }
    }
}
