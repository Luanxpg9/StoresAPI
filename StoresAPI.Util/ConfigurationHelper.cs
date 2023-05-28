using Microsoft.Extensions.Configuration;

namespace StoresAPI.Util
{
    public class ConfigurationHelper
    {
        public static IConfiguration Get()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}