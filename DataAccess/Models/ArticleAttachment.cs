// <copyright file="ArticleAttachment.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace DataAccess.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("articleattachment")]
    public class ArticleAttachment
    {
        [Column("ArticleUrl"), Required, MaxLength(1024)]
        public string ArticleUrl { get; set; }

        [Column("AttachmentName"), MaxLength(512)]
        public string AttachmentName { get; set; }
        [Key]
        [Column("SourceUrl"), MaxLength(1024)]
        public string SourceUrl { get; set; }

        [Column("FileContent")]
        public byte[] FileContent { get; set; }

        [Column("CrawledDate")]
        public DateTime? CrawledDate { get; set; }
    }
}
