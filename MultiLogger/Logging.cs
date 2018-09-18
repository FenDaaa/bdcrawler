// <copyright file="Logging.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace MultiLogger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MultiLogger.Loggers;

    public static class Logging
    {
        static Logging()
        {
            Loggers = new List<ILogger>
            {
                new ConsoleLogger()
            };

            LogLevel = LogType.Information;
        }

        public static List<ILogger> Loggers { get; private set; }

        public static LogType LogLevel { get; set; }

        public static void WriteEntry(object sender, LogType type, string message, Exception exception = null, Guid? correlatedId = null)
        {
            if (type > LogLevel)
            {
                return;
            }

            Task.WaitAll(Loggers.Select(logger => logger.WriteEntry(sender, type, message, exception, correlatedId)).ToArray());
        }
    }
}
