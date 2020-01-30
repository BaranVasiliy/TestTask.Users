using AzureFromTheTrenches.Commanding.Abstractions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestTask.Users.BLL.DTOs.Users;

namespace TestTask.Users.Queries
{
    public class GetUsersQuery : ICommand<IActionResult>, ICommandHandlerBase
    {
    }
}