using AzureFromTheTrenches.Commanding.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Users.Commands
{
    public class DeleteUserCommand : ICommand<IActionResult>
    {
        public int Id { get; set; }
    }
}