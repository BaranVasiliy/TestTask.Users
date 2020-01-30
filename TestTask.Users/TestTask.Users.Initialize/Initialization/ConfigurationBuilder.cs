using Microsoft.Extensions.Configuration;

namespace TestTask.Users.Initialize.Initialization
{
    public static class ConfigurationBuilder
    {
        public static IConfigurationRoot Create(
            string basePath,
            string settingFileName = "appsettings.json")
        {
            return new Microsoft.Extensions.Configuration.ConfigurationBuilder().SetBasePath(basePath).AddJsonFile(settingFileName, false, true).AddEnvironmentVariables().Build();
        }
    }
}