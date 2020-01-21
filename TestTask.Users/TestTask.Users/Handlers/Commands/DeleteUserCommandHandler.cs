using AutoMapper;
using AzureFromTheTrenches.Commanding.Abstractions;
using System.Threading.Tasks;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Commands;

namespace TestTask.Users.Handlers.Commands
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
        }
        public async Task ExecuteAsync(DeleteUserCommand command)
        {
            GetUserDTO user = await _userService.GetUserAsync(command.Id);

            await _userService.DeleteUserAsync(user);
        }
    }
}