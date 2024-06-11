using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Utilities
{
    public class ApiClient
    {
        private string url;
        private static HttpClient _client;
        public static HttpClient Client
        {
            get
            {
                if (_client == null) return new HttpClient();
                return _client;
            }
        }

        public async Task<string> GetDataAsync()
        {
            try
            {
                var response = await _client.GetAsync(url);

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> PostDataAsync(object data)
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
