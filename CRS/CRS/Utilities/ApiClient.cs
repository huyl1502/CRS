using CRS.Services;
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
        private static HttpClient _client;
        public static HttpClient Client
        {
            get
            {
                if (_client == null) return new HttpClient();
                return _client;
            }
        }

        public async Task<string> GetDataAsync(string url)
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

        public static async Task<string> PostDataAsync(string url, object data, bool isUseToken = true)
        {
            try
            {
                var appSettingsConfig = new AppSettinngsService();
                var host = appSettingsConfig.Config.Host;

                var dataObjectHasToken = new {
                    url = url,
                    value = data
                };

                var jsonData = JsonConvert.SerializeObject(dataObjectHasToken);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(host, content);
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
