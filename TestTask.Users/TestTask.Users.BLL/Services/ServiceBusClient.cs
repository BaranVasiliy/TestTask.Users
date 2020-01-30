using Dawn;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using TestTask.Users.BLL.Services.Contracts;

namespace TestTask.Users.BLL.Services
{
    public class ServiceBusClient : IServiceBusClient
    {
        private readonly IServiceBusPersistentConnection _persistentConnection;

        public ServiceBusClient(
            IServiceBusPersistentConnection persistentConnection)
        {
            _persistentConnection = Guard.Argument(persistentConnection, nameof(persistentConnection))
                .NotNull()
                .Value;
        }

        public async Task PublishAsync<T>(T busEvent, string topicName)
        {
            await PublishAsync(busEvent, null, topicName);
        }

        public async Task PublishAsync<T>(T busEvent, string label, string topicName)
        {
            Guard.Argument(topicName, nameof(topicName))
                .NotNull()
                .NotEmpty();

            string jsonMessage = JsonConvert.SerializeObject(busEvent);
            byte[] body = Encoding.UTF8.GetBytes(jsonMessage);

            Message message = new Message(body);

            if (!string.IsNullOrEmpty(label))
            {
                message.Label = label;
            }

            ITopicClient client = _persistentConnection.CreateTopicClient(topicName);

            await client.SendAsync(message);
        }
    }
}