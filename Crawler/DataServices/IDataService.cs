// <copyright file="IDataService.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.DataServices
{
    using System.Collections.Generic;
    using DataAccess.Models;

    public interface IDataService
    {
        void AddOrUpdateArticles(IEnumerable<Article> articles, ArticleMonitor monitor);

        void AddOrUpdateArticleAttachments(IEnumerable<ArticleAttachment> attachments);

        void AddOrUpdateArticleMontior(ArticleMonitor monitor);

        void AddLog(CrawlerLog log);

        void SaveChanges();
    }
}
