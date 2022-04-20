using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace ConfigurationHelper
{
    /// <summary>
    /// This class helps to get configuration values, first look Environment variables then appsettings.json or every file that has been loaded from IConfiguration instance.
    /// </summary>
    public class ConfigurationHelper
    {
        /// <summary>
        /// IConfiguration Local Variable
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public ConfigurationHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        /// <summary>
        /// Get configuration value
        /// </summary>
        /// <param name="key">configuration key, It can be "ServerAddress" or "Connections:ServerAddress" and etc.</param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            try
            {
                string temp = Environment.GetEnvironmentVariable(key.Split(':').Last());
                if (string.IsNullOrWhiteSpace(temp))
                    return _configuration.GetValue<string>(key);
                else
                    return temp;

            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }
    }

    
}
