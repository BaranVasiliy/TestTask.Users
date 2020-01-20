using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask.Users.BLL.DTOs.Address
{
    public class GetAddressDto
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string AddressLine { get; set; }
    }
}