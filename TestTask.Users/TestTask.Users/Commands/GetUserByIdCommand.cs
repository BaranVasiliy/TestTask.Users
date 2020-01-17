using AzureFromTheTrenches.Commanding.Abstractions;
using TestTask.Users.BLL.DTOs.Users;

namespace TestTask.Users.Commands
{
    public class GetUserByIdCommand : ICommand<GetUserDto>
    {
        public int Id { get; set; }
    }
}