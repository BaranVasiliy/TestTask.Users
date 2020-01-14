using AzureFromTheTrenches.Commanding.Abstractions;
using TestTask.Users.BLL.DTOs.Users;

namespace TestTask.Users.Commands
{
    public class GetUserCommand : ICommand<GetUserDTO>
    {
        public int Id { get; set; }
    }
}