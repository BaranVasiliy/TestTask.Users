using AzureFromTheTrenches.Commanding.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services;
using TestTask.Users.Commands;


namespace TestTask.Users.Handlers
{
    public class GetUsersCommandHandlers : ICommandHandler<GetUsersCommand, List<GetUsersDTO>>
    {
        private readonly IUserService _userService;

        public GetUsersCommandHandlers(IUserService userService)
        {
            _userService = userService;
        }

        public Task<List<GetUsersDTO>> ExecuteAsync(GetUsersCommand command, List<GetUsersDTO> previousResult)
        {
            return _userService.GetUsersAsync();
        }
    }
}