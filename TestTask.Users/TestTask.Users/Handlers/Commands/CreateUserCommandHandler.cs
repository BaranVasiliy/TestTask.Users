using AutoMapper;
using AzureFromTheTrenches.Commanding.Abstractions;
using System.Threading.Tasks;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Commands;

namespace TestTask.Users.Handlers.Commands
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;

            _userService = userService;
        }

        public async Task ExecuteAsync(CreateUserCommand command)
        {
            CreateUserDto user = _mapper.Map<CreateUserDto>(command);

            await _userService.CreateUserAsync(user);
        }
    }
}