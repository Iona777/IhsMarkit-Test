using Microsoft.Extensions.Configuration;

namespace IHSMarkit_TestProject.Utilities
{
    public class ConfigHelper
    {
        private static string configFile = "appsettings.QA.json";

        public static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile(configFile, optional: false, reloadOnChange: true);

            return builder.Build();
        }

    }
}
