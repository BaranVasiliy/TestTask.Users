using System;
using AzureFromTheTrenches.Commanding.Abstractions;

namespace TestTask.Users.Commands.Bus
{
    public class AddUserCommand : ICommand
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DataBirth { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}