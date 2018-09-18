// <copyright file="CrawlerDbContext.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace DataAccess
{
    using System.Data.Common;
    using System.Data.Entity;
    using System.Diagnostics.CodeAnalysis;
    using Models;
    using MySql.Data.Entity;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    [ExcludeFromCodeCoverage]
    public class CrawlerDbContext : DbContext
    {
        public CrawlerDbContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleAttachment> ArticleAttachments { get; set; }

        public DbSet<ArticleMonitor> ArticleMonitors { get; set; }

        public DbSet<CrawlerLog> CrawlerLogs { get; set; }
    }
}
