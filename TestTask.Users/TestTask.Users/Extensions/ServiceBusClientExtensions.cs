using System.Threading.Tasks;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services.Contracts;

namespace TestTask.Users.Extensions
{
    public static class ServiceBusClientExtensions
    {
        public static async Task PublishUserUpdatedAsync(
            this IServiceBusClient serviceBusClient, CreateUserDto createUserDto)
        {
            await serviceBusClient.PublishAsync(
                createUserDto, "Created_User", "testtopic");
        }
    }
}