using System;

namespace TestTask.Users.DAL.EF.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateBirth { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }
    }
}