using AzureFromTheTrenches.Commanding.Abstractions;

namespace TestTask.Users.Commands
{
    public class DeleteUserCommand : ICommand
    {
        public int Id { get; set; }
    }
}
