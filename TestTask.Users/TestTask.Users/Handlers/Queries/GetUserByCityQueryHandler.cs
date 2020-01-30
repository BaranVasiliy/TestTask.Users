using System.Collections.Generic;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using Microsoft.AspNetCore.Mvc;
using TestTask.Users.BLL.DTOs.Pagination;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Handlers.Abstracts;
using TestTask.Users.Queries;

namespace TestTask.Users.Handlers.Queries
{
    public class GetUserByCityQueryHandler : BaseActionHandler<GetUserByCityQuery>,
        ICommandHandler<GetUserByCityQuery, IActionResult>
    {
        private readonly IUserService _userService;

        public GetUserByCityQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        protected override async Task<IActionResult> ExecuteAction(GetUserByCityQuery command)
        {
            List<GetUserDTO> user = await _userService.GetUserByCityAsync(command.City);

            PagedResultDto<GetUserDTO> dataPaged = _userService.GetPaged(user, 1, 1);

            if (dataPaged == null)
            {
                return NotFound();
            }

            return Ok(dataPaged);
        }
    }
}