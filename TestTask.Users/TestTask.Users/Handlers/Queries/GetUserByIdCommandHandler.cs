using AzureFromTheTrenches.Commanding.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Handlers.Abstracts;
using TestTask.Users.Queries;

namespace TestTask.Users.Handlers.Queries
{
    public class GetUserByIdCommandHandler : BaseActionHandler<GetUserByIdQuery>, ICommandHandler<GetUserByIdQuery, IActionResult>
    {
        private readonly IUserService _userService;

        public GetUserByIdCommandHandler(IUserService userService)
        {
            _userService = userService;
        }


        protected override async Task<IActionResult> ExecuteAction(GetUserByIdQuery command)
        {
            var user = await _userService.GetUserAsync(command.Id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}