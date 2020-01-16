using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask.Users.BLL.DTOs.Users
{
    public class UpdateUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DataBirth { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
