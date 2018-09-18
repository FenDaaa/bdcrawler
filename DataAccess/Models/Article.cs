// <copyright file="Article.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace DataAccess.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("article")]
    public class Article
    {
        [Key]
        [Column("Url"), Required, MaxLength(1024)]
        public string Url { get; set; }

        [Column("SiteName"), Required, MaxLength(32)]
        public string SiteName { get; set; }

        [Column("Title"), MaxLength(256)]
        public string Title { get; set; }

        [Column("Content")]
        public string Content { get; set; }

        [Column("Category"), MaxLength(128)]
        public string Category { get; set; }

        [Column("IndexCode"), MaxLength(64)]
        public string IndexCode { get; set; }

        [Column("IssueCode"), MaxLength(64)]
        public string IssueCode { get; set; }

        [Column("PublishAgency"), MaxLength(512)]
        public string PublishAgency { get; set; }

        [Column("PublishDate")]
        public DateTime? PublishDate { get; set; }

        [Column("Keyword"), MaxLength(128)]
        public string Keyword { get; set; }

        [Column("CrawledDate")]
        public DateTime? CrawledDate { get; set; }

        [Column("IsShow")]
        public int IsShow { get; set; }

        [Column("IsCenter")]
        public int IsCenter { get; set; }
    }
}
