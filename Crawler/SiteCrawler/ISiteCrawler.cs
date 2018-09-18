// <copyright file="ISiteCrawler.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.SiteCrawler
{
    using DataAccess.Models;

    public interface ISiteCrawler
    {
        void Crawl(SiteParameter siteParameter);
    }
}
