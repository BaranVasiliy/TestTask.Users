using AzureFromTheTrenches.Commanding.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Handlers.Abstracts;
using TestTask.Users.Queries;

namespace TestTask.Users.Handlers.Queries
{
    public class GetUsersCommandHandlers : BaseActionHandler<GetUsersQuery>, ICommandHandler<GetUsersQuery, IActionResult>
    {
        private readonly IUserService _userService;

        public GetUsersCommandHandlers(IUserService userService)
        {
            _userService = userService;
        }

        protected  override async Task<IActionResult> ExecuteAction(GetUsersQuery command)
        {
            List<GetUserDTO> user = await _userService.GetUsersAsync();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}