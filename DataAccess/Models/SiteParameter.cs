// <copyright file="SiteParameter.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace DataAccess.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class SiteParameter
    {
        public string SiteName { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public string StartUrl { get; set; }

        public string UrlPattern { get; set; }

        public string ItemPattern { get; set; }

        public string ContentPattern { get; set; }

        public int StartNumber { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? PageStepNumber { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? IsCenter { get; set; }

        public int CaptionPosition { get; set; }

        public int UrlPosition { get; set; }

        public int DatePosition { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CategoryPattern { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string IndexCodePattern { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string IssueCodePattern { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PublishAgencyPattern { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PublishDatePattern { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string KeywordPattern { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string AttachmentPattern { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> CustomProcessors { get; set; }
    }
}
