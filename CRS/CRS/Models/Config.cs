﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRS.Models
{
    public class RatingIconConfig
    {
        [JsonProperty("ListRatingIcon")]
        public List<RatingIcon> ListRatingIcon { get; set; }

        public class RatingIcon
        {
            [JsonProperty("UnSelectedIcon")]
            public string UnSelectedIcon { get; set; }

            [JsonProperty("SelectedIcon")]
            public string SelectedIcon { get; set; }

            [JsonProperty("Label")]
            public string Label { get; set; }

            [JsonProperty("Point")]
            public int Point { get; set; }
        }
    }

    public class ReasonConfig
    {
        [JsonProperty("ListReason")]
        public List<Reason> ListReason { get; set; }

        public class Reason {
            [JsonProperty("Point")]
            public int Point { get; set; }

            [JsonProperty("Values")]
            public List<string> Values { get; set; }
        }
    }

    public class AppSettinngs
    {
        [JsonProperty("Host")]
        public string Host { get; set; }
    }
}
