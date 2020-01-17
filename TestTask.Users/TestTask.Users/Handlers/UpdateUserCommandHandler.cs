using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using AzureFromTheTrenches.Commanding.Abstractions;
using Microsoft.AspNetCore.Http.Internal;
using Remotion.Linq.Clauses;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Commands;
using TestTask.Users.DAL.EF.Entities;

namespace TestTask.Users.Handlers
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
            GetUserDto user = await _userService.GetUserAsync(command.Id);
            user.FirstName = command.FirstName;

            UpdateUserDto result = _mapper.Map<UpdateUserDto>(user);
            await _userService.UpdateUserAsync(result);
        }
    }
}
