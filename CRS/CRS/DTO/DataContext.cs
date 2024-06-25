using System;
using CRS.Models;
using Newtonsoft.Json;

namespace CRS.DTO
{
	public class DataContext<T>
	{
        [JsonProperty("value")]
        public T Value { get; set; }
    }
}

