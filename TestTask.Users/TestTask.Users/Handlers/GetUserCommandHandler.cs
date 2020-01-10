using AzureFromTheTrenches.Commanding.Abstractions;
using Microsoft.Azure.Documents;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Users.Commands;
using TestTask.Users.Models;
using User = TestTask.Users.Models.User;


namespace TestTask.Users.Handlers
{
    public class GetUserCommandHandlers : ICommandHandler<GetUserCommand, List<User>>
    {
        public Task<List<User>> ExecuteAsync(GetUserCommand command, List<User> previousResult)
        {
            if (command.Users == null)
            {
                command.Users = new List<User>();
                command.Users.Add(new User() { FirstName= "Name", LastName = "Name" });
                return Task.FromResult(command.Users);
            }
            return Task.FromResult(command.Users);
        }
    }
}
