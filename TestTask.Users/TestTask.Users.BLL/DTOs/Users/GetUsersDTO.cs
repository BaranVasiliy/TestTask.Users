using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask.Users.BLL.DTOs.Users
{
    public class GetUsers
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
