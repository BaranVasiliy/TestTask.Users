using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using TestTask.Users.Initialize.Initialization;
using ConfigurationBuilder = TestTask.Users.Initialize.Initialization.ConfigurationBuilder;

namespace TestTask.Users.Initialize
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            IConfigurationRoot config = ConfigurationBuilder.Create(Directory.GetCurrentDirectory());

            await AzureServiceBusInitializer.InitializeAsync(config);
        }
    }
}