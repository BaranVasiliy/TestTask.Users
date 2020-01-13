using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask.Users.BLL.DTOs.Users
{
    public class GetUsersDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}