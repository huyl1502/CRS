using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using CRS.DTO;
using CRS.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace CRS.Utilities
{
	public class Utilities
	{
		public static List<PhysicalAddress> GetMacAddress()
		{
            var lstAddress = new List<PhysicalAddress>();
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                lstAddress.Add(nic.GetPhysicalAddress());
            }
            return lstAddress;
        }

        public static async Task SaveTokenAsync(string token)
        {
            try
            {
                await SecureStorage.SetAsync("Token", token);
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
                Console.WriteLine("Error saving token: " + ex.Message);
            }
        }

        public static async Task<string> GetTokenAsync()
        {
            try
            {
                return await SecureStorage.GetAsync("Token");
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
                Console.WriteLine("Error retrieving token: " + ex.Message);
                return null;
            }
        }

        public static T TryDeserialize<T>(string json)
        {
            try
            {
                var firstTypeObject = JsonConvert.DeserializeObject<DataContext<T>>(json);
                return firstTypeObject.Value;
            }
            catch (Exception) 
            {
                try
                {
                    var errorObject = JsonConvert.DeserializeObject<ErrorResponse>(json);
                    throw new Exception(errorObject.Message);
                }
                catch (Exception)
                {
                    throw new InvalidOperationException("Deserialization to both types failed.");
                }
            }
        }
    }
}

