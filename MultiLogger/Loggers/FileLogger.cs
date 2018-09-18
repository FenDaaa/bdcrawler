// <copyright file="FileLogger.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace MultiLogger.Loggers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Threading.Tasks;

    [ExcludeFromCodeCoverage]
    public class FileLogger : ILogger
    {
        private string path = null;

        public FileLogger(string path)
        {
            this.path = path;
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch
            {
                path = null;
            }
        }

        public async Task WriteEntry(object sender, LogType type, string message, Exception exception = null, Guid? correlatedId = null)
        {
            if (this.path == null)
            {
                return;
            }

            string fileName = DateTime.Now.ToString("yyyy_MM_dd") + ".log";
            string fullPath = Path.Combine(this.path, fileName);

            string item = $"{DateTime.Now}\t{correlatedId}\t{sender}\t{type}\t{message}\t{exception}\r\n";

            await Task.Run(() =>
            {
                lock (item)
                {
                    try
                    {
                        File.AppendAllText(fullPath, item);
                    }
                    catch
                    {
                        path = null;
                    }
                }
            });
        }
    }
}
