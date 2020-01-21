using AzureFromTheTrenches.Commanding.Abstractions;
using System;
using Microsoft.AspNetCore.Mvc;
using TestTask.Users.BLL.DTOs.Address;

namespace TestTask.Users.Commands
{
    public class CreateUserCommand : ICommand<IActionResult>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DataBirth { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public CreateAddressDto Address { get; set; }
    }
}