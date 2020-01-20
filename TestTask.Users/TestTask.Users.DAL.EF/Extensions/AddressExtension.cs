using Microsoft.EntityFrameworkCore;
using TestTask.Users.DAL.EF.Entities;

namespace TestTask.Users.DAL.EF.Extensions
{
    public static class AddressExtension
    {
        public static void BuildAddressModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(i => i.Id);

                entity.Property(p => p.Country).HasMaxLength(30).IsRequired();

                entity.Property(p => p.City).HasMaxLength(30).IsRequired();

                entity.Property(p => p.AddressLine).HasMaxLength(200).IsRequired();

                entity.Property(p => p.PostalCode).HasMaxLength(10).IsRequired();
            });
        }
    }
}