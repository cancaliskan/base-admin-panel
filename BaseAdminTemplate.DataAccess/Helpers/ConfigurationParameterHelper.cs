using System.IO;
using Microsoft.Extensions.Configuration;

namespace BaseAdminTemplate.DataAccess.Helpers
{
    public static class ConfigurationParameterHelper
    {
        public static string GetConfigurationParameter(string key)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("configurationParameters.json")
                .Build();

            var value = configuration.GetConnectionString(key);
            return value;
        }
    }
}