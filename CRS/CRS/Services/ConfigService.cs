using CRS.Models;
using CRS.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CRS.Services
{
    public abstract class ConfigService<T>
    {
        public T Config { get; private set; }
        public ConfigService(string jsonFileName)
        {
            Config = LoadConfig(jsonFileName);
        }

        static T LoadConfig(string jsonFileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resName = assembly.GetManifestResourceNames()
                ?.FirstOrDefault(r => r.EndsWith(jsonFileName, StringComparison.OrdinalIgnoreCase));
            Stream stream = assembly.GetManifestResourceStream(resName);

            using (var reader = new StreamReader(stream))
            {

                var json = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<T>(json);
                return data;
            }
        }
    }

    public class RatingIconConfigService : ConfigService<RatingIconConfig> {
        public RatingIconConfigService() : base("rating_icon.json") { }
    }

    public class ReasonConfigService : ConfigService<ReasonConfig>
    {
        public ReasonConfigService() : base("reason.json") { }
    }

    public class AppSettinngsService : ConfigService<AppSettinngs>
    {
        public AppSettinngsService() : base("appsettings.json") { }
    }
}
