using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AzureFromTheTrenches.Commanding.Abstractions;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Commands;

namespace TestTask.Users.Handlers
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task ExecuteAsync(DeleteUserCommand command)
        {
            GetUserDto user = await _userService.GetUserAsync(command.Id);
            await _userService.DeleteUserAsync(user);
        }
    }
}
