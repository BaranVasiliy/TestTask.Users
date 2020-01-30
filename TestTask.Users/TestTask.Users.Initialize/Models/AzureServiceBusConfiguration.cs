using System.Collections.Generic;

namespace TestTask.Users.Initialize.Models
{
    public class AzureServiceBusConfiguration
    {
        public string ConnectionString { get; set; }

        public IEnumerable<Topic> Topics { get; set; }
    }
}