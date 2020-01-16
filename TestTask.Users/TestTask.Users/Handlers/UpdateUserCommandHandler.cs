using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Commands;

namespace TestTask.Users.Handlers
{
    class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, GetUserDto>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<GetUserDto> ExecuteAsync(UpdateUserCommand command, GetUserDto previousResult)
        {
            return await _userService.UpdateUserAsync();
        }
    }
}
