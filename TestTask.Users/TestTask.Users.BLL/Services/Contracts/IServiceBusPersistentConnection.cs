using Microsoft.Azure.ServiceBus;

namespace TestTask.Users.BLL.Services.Contracts
{
    public interface IServiceBusPersistentConnection
    {
        ITopicClient CreateTopicClient(string topicName);
    }
}