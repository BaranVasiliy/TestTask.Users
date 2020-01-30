using AzureFromTheTrenches.Commanding.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Users.Queries
{
    public class GetUserByCityQuery : ICommand<IActionResult>
    {
        public string City { get; set; }
    }
}