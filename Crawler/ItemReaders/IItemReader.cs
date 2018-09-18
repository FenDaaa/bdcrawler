// <copyright file="IItemReader.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.ItemReaders
{
    using System.Collections.Generic;
    using DataAccess.Models;

    public interface IItemReader
    {
        IEnumerable<Article> GetArticles(string html, string pageUrl);
    }
}