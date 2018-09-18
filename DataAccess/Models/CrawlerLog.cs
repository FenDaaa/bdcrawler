// <copyright file="CrawlerLog.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace DataAccess.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("crawlerlog")]
    public class CrawlerLog
    {
        [Key]
        [Column("ID"), Required]
        public int Id { get; set; }

        [Column("Url"), Required, MaxLength(1024)]
        public string Url { get; set; }

        [Column("Message")]
        public string Message { get; set; }

        [Column("LogTime")]
        public DateTime? LogTime { get; set; }
    }
}
