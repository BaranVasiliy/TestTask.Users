using System.Threading.Tasks;

namespace TestTask.Users.BLL.Services.Contracts
{
    public interface IServiceBusClient
    {
        Task PublishAsync<T>(T busEvent, string topicName);

        Task PublishAsync<T>(T busEvent, string label, string topicName);
    }
}