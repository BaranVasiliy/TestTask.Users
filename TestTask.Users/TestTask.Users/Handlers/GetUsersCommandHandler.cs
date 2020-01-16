using AzureFromTheTrenches.Commanding.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Commands;


namespace TestTask.Users.Handlers
{
    public class GetUsersCommandHandlers : ICommandHandler<GetUsersCommand, List<GetUserDto>>
    {
        private readonly IUserService _userService;

        public GetUsersCommandHandlers(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<GetUserDto>> ExecuteAsync(GetUsersCommand command, List<GetUserDto> previousResult)
        {
           return await _userService.GetUsersAsync();
        }
    }
}