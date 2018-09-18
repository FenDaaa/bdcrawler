// <copyright file="ConsoleLogger.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace MultiLogger.Loggers
{
    using System;
    using System.Threading.Tasks;

    public class ConsoleLogger : ILogger
    {
        public async Task WriteEntry(object sender, LogType type, string message, Exception exception = null, Guid? correlatedId = null)
        {
            string item = $"{DateTime.Now.ToShortTimeString()} - {message}\t{exception?.Message}";
            await Task.Run(() =>
            {
                switch (type)
                {
                    case LogType.Error:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;

                    case LogType.Warning:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                }

                Console.WriteLine(item);
                Console.ForegroundColor = ConsoleColor.Gray;
            });
        }
    }
}
