using AzureFromTheTrenches.Commanding.Abstractions;
using TestTask.Users.BLL.DTOs.Users;

namespace TestTask.Users.Queries
{
    public class GetUserByIdCommand : ICommand<GetUserDTO>
    {
        public int Id { get; set; }
    }
}