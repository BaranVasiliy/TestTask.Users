using System.Collections.Generic;
using AzureFromTheTrenches.Commanding.Abstractions;
using TestTask.Users.Models;


namespace TestTask.Users.Commands
{
    public class GetUserCommand : ICommand<List<User>>
    {
        public List<User> Users { get; set; }
    }
}
