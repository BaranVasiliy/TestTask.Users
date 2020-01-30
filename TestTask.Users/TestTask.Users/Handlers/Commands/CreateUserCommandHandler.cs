using AutoMapper;
using AzureFromTheTrenches.Commanding.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Commands;
using TestTask.Users.Extensions;
using TestTask.Users.Handlers.Abstracts;

namespace TestTask.Users.Handlers.Commands
{
    public class CreateUserCommandHandler : BaseActionHandler<CreateUserCommand>,
        ICommandHandler<CreateUserCommand, IActionResult>
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        private readonly IServiceBusClient _serviceBusClient;

        public CreateUserCommandHandler(IUserService userService, IMapper mapper, IServiceBusClient serviceBusClient)
        {
            _mapper = mapper;
            _serviceBusClient = serviceBusClient;
            _userService = userService;
        }

        protected override async Task<IActionResult> ExecuteAction(CreateUserCommand command)
        {
            CreateUserDto user = _mapper.Map<CreateUserDto>(command);

            await _serviceBusClient.PublishUserUpdatedAsync(user);
            if (user == null)
            {
                return NotFound();
            }
            
            return Ok(await _userService.CreateUserAsync(user));
        }
    }
}