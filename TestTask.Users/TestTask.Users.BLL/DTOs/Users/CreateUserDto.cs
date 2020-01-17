using System;

namespace TestTask.Users.BLL.DTOs.Users
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DataBirth { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}