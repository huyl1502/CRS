using System;
using Newtonsoft.Json;

namespace CRS.Models
{
	public class Account
	{
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("Role")]
        public string Role { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}

