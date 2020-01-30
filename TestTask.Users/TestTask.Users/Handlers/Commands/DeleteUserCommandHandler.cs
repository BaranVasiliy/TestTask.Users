using AutoMapper;
using AzureFromTheTrenches.Commanding.Abstractions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Commands;
using TestTask.Users.Handlers.Abstracts;

namespace TestTask.Users.Handlers.Commands
{
    public class DeleteUserCommandHandler : BaseActionHandler<DeleteUserCommand>,
        ICommandHandler<DeleteUserCommand, IActionResult>
    {
        private readonly IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
        }

        protected override async Task<IActionResult> ExecuteAction(DeleteUserCommand command)
        {
            GetUserDTO user = await _userService.GetUserAsync(command.Id);

            if (user != null)
            {
                await _userService.DeleteUserAsync(user);
            }

            return Ok(user);
        }
    }
}