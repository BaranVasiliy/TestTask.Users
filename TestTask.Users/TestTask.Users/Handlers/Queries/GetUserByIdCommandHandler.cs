using AzureFromTheTrenches.Commanding.Abstractions;
using System.Threading.Tasks;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Queries;

namespace TestTask.Users.Handlers.Queries
{
    public class GetUserByIdCommandHandler : ICommandHandler<GetUserByIdCommand, GetUserDTO>
    {
        private readonly IUserService _userService;

        public GetUserByIdCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUserDTO> ExecuteAsync(GetUserByIdCommand command, GetUserDTO previousResult)
        {
            return await _userService.GetUserAsync(command.Id);
        }
    }
}