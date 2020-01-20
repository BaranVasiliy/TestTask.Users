using System;
using TestTask.Users.BLL.DTOs.Address;

namespace TestTask.Users.BLL.DTOs.Users
{
    public class GetUserDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateBirth { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int AddressId { get; set; }

        public GetAddressDto Address { get; set; }
    }
}