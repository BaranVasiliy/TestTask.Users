using AzureFromTheTrenches.Commanding.Abstractions;
using Microsoft.AspNetCore.Mvc;
using TestTask.Users.BLL.DTOs.Users;

namespace TestTask.Users.Queries
{
    public class GetUserByIdQuery : ICommand<IActionResult>
    {
        public int Id { get; set; }
    }
}