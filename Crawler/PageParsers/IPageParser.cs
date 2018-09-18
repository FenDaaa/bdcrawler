// <copyright file="IPageParser.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.PageParsers
{
    using System;
    using System.Collections.Generic;
    using DataAccess.Models;

    public interface IPageParser
    {
        Article GetArticleDetails(Article article);

        IEnumerable<ArticleAttachment> GetAttachments(Article article);

        void SetErrorHandler(Action<string, Exception> errorHandler);
    }
}
