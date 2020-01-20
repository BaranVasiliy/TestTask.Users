using AzureFromTheTrenches.Commanding.Abstractions;
using TestTask.Users.BLL.DTOs.Users;

namespace TestTask.Users.Commands
{
    public class GetUserByIdCommand : ICommand<GetUserDTO>
    {
        public int Id { get; set; }
    }
}