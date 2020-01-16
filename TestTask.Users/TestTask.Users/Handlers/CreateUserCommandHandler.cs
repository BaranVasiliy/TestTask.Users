using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Commands;
using TestTask.Users.DAL.EF.Repositories.Contracts;

namespace TestTask.Users.Handlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }


        public async Task ExecuteAsync(CreateUserCommand command)
        {
            CreateUserDto user = create(command);
            await _userService.CreateUserAsync(user);
        }

        private CreateUserDto create(CreateUserCommand command)
        {
            return new CreateUserDto
            {
                FirstName =  command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Phone = command.Phone,
                DataBirth = DateTime.UtcNow
            };
        }
    }
}
