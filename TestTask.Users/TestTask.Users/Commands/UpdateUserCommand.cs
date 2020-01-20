using AzureFromTheTrenches.Commanding.Abstractions;
using System;
using TestTask.Users.BLL.DTOs.Users;

namespace TestTask.Users.Commands
{
    public class UpdateUserCommand : ICommand
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DataBirth { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public GetUserDTO Address { get; set; }
    }
}