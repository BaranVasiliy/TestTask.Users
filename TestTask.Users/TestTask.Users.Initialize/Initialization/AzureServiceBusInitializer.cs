using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using TestTask.Users.Initialize.Models;

namespace TestTask.Users.Initialize.Initialization
{
    public static class AzureServiceBusInitializer
    {
        public static async Task InitializeAsync(
            IConfigurationRoot configuration,
            string sectionName = "AzureServiceBus")
        {
            Console.WriteLine("Start Azure Service Bus initialization....");
            AzureServiceBusConfiguration azureServiceBusConfiguration = new AzureServiceBusConfiguration();
            configuration.GetSection(sectionName).Bind((object)azureServiceBusConfiguration);
            await ServiceBusSubscriber.AddRulesAsync(azureServiceBusConfiguration);
            Console.WriteLine("End Azure Service Bus initialization....");
        }
    }
}