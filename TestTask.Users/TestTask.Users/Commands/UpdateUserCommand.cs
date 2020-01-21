using AzureFromTheTrenches.Commanding.Abstractions;
using System;
using Microsoft.AspNetCore.Mvc;
using TestTask.Users.BLL.DTOs.Address;

namespace TestTask.Users.Commands
{
    public class UpdateUserCommand : ICommand<IActionResult>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DataBirth { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public UpdateAddressDto Address { get; set; }
    }
}