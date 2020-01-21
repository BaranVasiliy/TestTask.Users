namespace TestTask.Users.DAL.EF.Entities
{
    public class Address
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string AddressLine { get; set; }

        public int UserAddressId { get; set; }

        public User User { get; set; }
    }
}