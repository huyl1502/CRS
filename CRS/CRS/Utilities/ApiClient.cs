using CRS.DTO;
using CRS.Models;
using CRS.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public static async Task<string> GetDataAsync<T>(string url)
        {
            try
            {
                var response = await Client.GetAsync(url);

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<T> PostDataAsync<T>(string url, object data)
        {
            try
            {
                var appSettingsConfig = new AppSettinngsService();
                var host = appSettingsConfig.Config.Host;

                var dataObject = new
                {
                    token = Utilities.GetTokenAsync().Result,
                    url = url,
                    value = data
                };

                var jsonData = JsonConvert.SerializeObject(dataObject);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await Client.PostAsync(host, content);
                response.EnsureSuccessStatusCode();

                string responseData = await response.Content.ReadAsStringAsync();

                var dataContext = Utilities.TryDeserialize<T>(responseData);

                return dataContext;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
