// <copyright file="CrawlerDbHelper.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace DataAccess
{
    using System.Diagnostics.CodeAnalysis;
    using MySql.Data.MySqlClient;

    [ExcludeFromCodeCoverage]
    public static class CrawlerDbHelper
    {
        private static string connectionString = string.Empty;

        public static void Init(string conStr)
        {
            connectionString = conStr;
        }

        public static CrawlerDbContext GetContext()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            CrawlerDbContext context = new CrawlerDbContext(connection, true);
            return context;
        }
    }
}
