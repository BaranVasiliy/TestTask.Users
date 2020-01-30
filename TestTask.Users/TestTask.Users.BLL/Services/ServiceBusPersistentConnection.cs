using System;
using System.Collections.Generic;
using System.Text;
using Dawn;
using Microsoft.Azure.ServiceBus;
using TestTask.Users.BLL.Services.Contracts;

namespace TestTask.Users.BLL.Services
{
    public class ServiceBusPersistentConnection : IServiceBusPersistentConnection
    {
        private readonly Dictionary<string, ITopicClient> _topicClients;

        private readonly string _connectionString;

        public ServiceBusPersistentConnection(string connectionString = "Endpoint=sb://testtaskuser.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=eZBpPYFYgiwzlv8E38St9ni7yI4H1iC6sV1Isgwsw1Q=")
        {
            _connectionString = Guard.Argument(connectionString, nameof(connectionString))
                .NotNull()
                .NotEmpty()
                .Value;

            _topicClients = new Dictionary<string, ITopicClient>();
        }

        public ITopicClient CreateTopicClient(string topicName)
        {
            if (!_topicClients.ContainsKey(topicName) || _topicClients[topicName].IsClosedOrClosing)
            {
                ITopicClient topicClient = BuildTopicClient(topicName);

                if (_topicClients.ContainsKey(topicName))
                {
                    _topicClients[topicName] = topicClient;
                }
                else
                {
                    _topicClients.Add(topicName, topicClient);
                }
            }

            return _topicClients[topicName];
        }

        private ITopicClient BuildTopicClient(string topicName)
        {
            ServiceBusConnectionStringBuilder builder
                = new ServiceBusConnectionStringBuilder(_connectionString)
                {
                    EntityPath = topicName
                };

            return new TopicClient(builder, RetryPolicy.Default);
        }
    }
}
