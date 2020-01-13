﻿using AzureFromTheTrenches.Commanding.Abstractions;
using System.Threading.Tasks;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services;
using TestTask.Users.Commands;

namespace TestTask.Users.Handlers
{
    public class GetUserCommandHandler : ICommandHandler<GetUserCommand, GetUsersDTO>
    {
        private readonly IUserService _userService;

        public GetUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Task<GetUsersDTO> ExecuteAsync(GetUserCommand command, GetUsersDTO previousResult)
        {
            return _userService.GetUserAsync(2);
        }
    }
}