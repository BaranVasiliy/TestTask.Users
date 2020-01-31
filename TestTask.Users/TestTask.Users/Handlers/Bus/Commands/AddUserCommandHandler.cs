using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using TestTask.Users.Commands.Bus;

namespace TestTask.Users.Handlers.Bus.Commands
{
    public class AddUserCommandHandler : ICommandHandler<AddUserCommand>
    {
        public async Task ExecuteAsync(AddUserCommand command)
        {
            await  Task.CompletedTask;
        }
    }
}