using System;
using TestTask.Users.BLL.DTOs.Address;

namespace TestTask.Users.BLL.DTOs.Users
{
    public class UpdateUserDto
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