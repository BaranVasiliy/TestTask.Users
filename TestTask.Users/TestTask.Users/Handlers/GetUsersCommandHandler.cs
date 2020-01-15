using AzureFromTheTrenches.Commanding.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Commands;


namespace TestTask.Users.Handlers
{
    public class GetUsersCommandHandlers : ICommandHandler<GetUsersCommand, List<GetUserDTO>>
    {
        private readonly IUserService _userService;

        public GetUsersCommandHandlers(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<GetUserDTO>> ExecuteAsync(GetUsersCommand command, List<GetUserDTO> previousResult)
        {
           return await _userService.GetUsersAsync();
        }
    }
}