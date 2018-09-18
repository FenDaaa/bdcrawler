// <copyright file="ILogger.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace MultiLogger
{
    using System;
    using System.Threading.Tasks;

    public enum LogType
    {
        Error,

        Warning,

        Information
    }

    public interface ILogger
    {
        Task WriteEntry(object sender, LogType type, string message, Exception exception = null, Guid? correlatedId = null);
    }
}
