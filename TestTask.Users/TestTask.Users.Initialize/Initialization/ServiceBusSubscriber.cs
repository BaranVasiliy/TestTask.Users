using Microsoft.Azure.ServiceBus;
using System;
using System.Threading.Tasks;
using TestTask.Users.Initialize.Models;

namespace TestTask.Users.Initialize.Initialization
{
    public static class ServiceBusSubscriber
    {
        public static async Task AddRulesAsync(AzureServiceBusConfiguration configuration)
        {
            ServiceBusConnectionStringBuilder connectionStringBuilder = new ServiceBusConnectionStringBuilder(configuration.ConnectionString);
            foreach (Topic topic1 in configuration.Topics)
            {
                Topic topic = topic1;
                Console.WriteLine("Topic: " + topic.Name + ". Start");
                connectionStringBuilder.EntityPath = topic.Name;
                foreach (Subscriber subscriber1 in topic.Subscribers)
                {
                    Subscriber subscriber = subscriber1;
                    Console.WriteLine("Subscriber: " + subscriber.Name + ". Start");
                    SubscriptionClient subscriptionClient = new SubscriptionClient(connectionStringBuilder, subscriber.Name, ReceiveMode.PeekLock, (RetryPolicy)null);
                    await ServiceBusSubscriber.AddRules(subscriber, subscriptionClient);
                    Console.WriteLine("Subscriber: " + subscriber.Name + ". End");
                    await subscriptionClient.CloseAsync();
                    subscriptionClient = (SubscriptionClient)null;
                    subscriber = (Subscriber)null;
                }
                Console.WriteLine("Topic: " + topic.Name + ". End");
                topic = (Topic)null;
            }
        }

        private static async Task AddRules(
          Subscriber subscriber,
          SubscriptionClient subscriptionClient)
        {
            foreach (string label1 in subscriber.Labels)
            {
                string label = label1;
                RuleDescription ruleDescription = new RuleDescription()
                {
                    Name = label,
                    Filter = (Filter)new CorrelationFilter()
                    {
                        Label = label
                    }
                };
                try
                {
                    await ServiceBusSubscriber.RemoveDefaultRuleAsync((ISubscriptionClient)subscriptionClient);
                    Console.WriteLine("Trying to add the following rule: Name: " + label + ", Label: " + label);
                    await subscriptionClient.AddRuleAsync(ruleDescription);
                    Console.WriteLine("Rule was successfully added");
                }
                catch (ServiceBusException ex) when (ex.Message != null && ex.Message.Contains("already exists", StringComparison.InvariantCulture))
                {
                    Console.WriteLine("The rule already exists");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Some error occurred: " + ex.Message);
                    throw;
                }
                ruleDescription = (RuleDescription)null;
                label = (string)null;
            }
        }

        private static async Task RemoveDefaultRuleAsync(ISubscriptionClient subscriptionClient)
        {
            try
            {
                await subscriptionClient.RemoveRuleAsync("$Default");
            }
            catch (MessagingEntityNotFoundException ex)
            {
                Console.WriteLine("Default rule does not exist.");
            }
        }
    }
}