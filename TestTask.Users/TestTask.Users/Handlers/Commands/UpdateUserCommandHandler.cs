using AutoMapper;
using AzureFromTheTrenches.Commanding.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Commands;
using TestTask.Users.Handlers.Abstracts;

namespace TestTask.Users.Handlers.Commands
{
    public class UpdateUserCommandHandler : BaseActionHandler<UpdateUserCommand>,
        ICommandHandler<UpdateUserCommand, IActionResult>
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        protected override async Task<IActionResult> ExecuteAction(UpdateUserCommand command)
        {
            UpdateUserDto result = _mapper.Map<UpdateUserDto>(command);

            if (result == null)
            {
                return NotFound();
            }
            
            return Ok(await _userService.UpdateUserAsync(result));
        }
    }
}