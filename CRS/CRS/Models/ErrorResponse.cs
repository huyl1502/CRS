using System;
using Newtonsoft.Json;

namespace CRS.Models
{
	public class ErrorResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}

