using System.Configuration;
using System.IO;

using Microsoft.Extensions.Configuration;

namespace GiGCodeChallenge.Tests.Helper
{
    public class ConfigurationHelper
    {
        public static string TestProvidedAPI => ConfigurationRoot[nameof(TestProvidedAPI)];

        public static IConfigurationRoot ConfigurationRoot { get; private set; }


        /// <summary>
        /// Build Configuration
        /// </summary>
        public static void BuildConfiguration()
        {
            if (ConfigurationRoot != null)
            {
                return;
            }
            var folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName 
                + "\\" + ConfigurationManager.AppSettings["ConfigurationFolder"];

            IConfigurationBuilder builder = new ConfigurationBuilder().
                SetBasePath(folder).
                AddJsonFile("config.json", false).AddEnvironmentVariables();

            ConfigurationRoot = builder.Build();
        }
    }
}
