using AzureFromTheTrenches.Commanding.Abstractions;
using System.Threading.Tasks;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Commands;

namespace TestTask.Users.Handlers
{
    public class GetUserCommandHandler : ICommandHandler<GetUserCommand, GetUserDto>
    {
        private readonly IUserService _userService;

        public GetUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUserDto> ExecuteAsync(GetUserCommand command, GetUserDto previousResult)
        {
            return await _userService.GetUserAsync(command.Id);
        }
    }
}