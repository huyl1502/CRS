using System;
using Newtonsoft.Json;

namespace CRS.Models
{
	public class DataContext<T>
	{
        [JsonProperty("value")]
        public T Value { get; set; }
	}
}

