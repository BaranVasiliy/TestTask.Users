using AutoMapper;
using AzureFromTheTrenches.Commanding.Abstractions;
using System.Threading.Tasks;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Commands;

namespace TestTask.Users.Handlers.Commands
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        public async Task ExecuteAsync(UpdateUserCommand command)
        {
            UpdateUserDto result = _mapper.Map<UpdateUserDto>(command);

            await _userService.UpdateUserAsync(result);
        }
    }
}