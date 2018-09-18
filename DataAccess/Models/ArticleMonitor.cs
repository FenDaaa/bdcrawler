// <copyright file="ArticleMonitor.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace DataAccess.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("articlemonitor")]
    public class ArticleMonitor
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("SiteName"), Required, MaxLength(32)]
        public string SiteName { get; set; }

        [Column("SiteUrl"), Required, MaxLength(1024)]
        public string SiteUrl { get; set; }

        [Column("Status")]
        public int Status { get; set; }

        [Column("StartTime")]
        public DateTime StartTime { get; set; }

        [Column("EndTime")]
        public DateTime EndTime { get; set; }

        [NotMapped]
        public DateTime? HistoryPublishDate { get; set; }

        [NotMapped]
        public DateTime? CurrentPublishDate { get; set; }

        [NotMapped]
        public int HistoryCount { get; set; }

        [NotMapped]
        public int CurrentCount { get; set; }
    }
}
