// <copyright file="Program.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using Crawler.SiteCrawler;
    using DataAccess;
    using DataAccess.Models;
    using MultiLogger;
    using MultiLogger.Loggers;
    using Newtonsoft.Json;

    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConStr"].ConnectionString;
            CrawlerDbHelper.Init(connectionString);
            using (var context = CrawlerDbHelper.GetContext())
            {
                if (!context.Database.Exists())
                {
                    // TODO: Create database here
                }
            }

            string logLevel = ConfigurationManager.AppSettings["MultiLogger.LogLevel"];
            if (!string.IsNullOrWhiteSpace(logLevel))
            {
                LogType level = LogType.Information;
                Enum.TryParse<LogType>(logLevel, out level);
                Logging.LogLevel = level;
            }

            string fileLoggerPath = ConfigurationManager.AppSettings["FileLogger.Path"];
            if (!string.IsNullOrWhiteSpace(fileLoggerPath))
            {
                FileLogger fileLogger = new FileLogger(fileLoggerPath);
                Logging.Loggers.Add(fileLogger);
            }

            string configPath = ConfigurationManager.AppSettings["ConfigurationFile"];
            if (string.IsNullOrWhiteSpace(configPath) || !File.Exists(configPath))
            {
                Console.WriteLine("Configuration file missing. \nPress any key to exit...");
                Console.ReadKey();
                return;
            }

            string config = File.ReadAllText(configPath);
            List<SiteParameter> siteParameters = JsonConvert.DeserializeObject<List<SiteParameter>>(config);

            foreach (var parameter in siteParameters)
            {
                Logging.WriteEntry("Main", LogType.Information, $"Starting crawler for {parameter.SiteName}");
                var crawler = CrawlerFactory.Create(parameter);
                crawler.Crawl(parameter);
                Logging.WriteEntry("Main", LogType.Information, $"Crawling {parameter.SiteName} done.");
            }

            #if DEBUG
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            #endif
        }
    }
}
