using Microsoft.EntityFrameworkCore;
using TestTask.Users.DAL.EF.Entities;

namespace TestTask.Users.DAL.EF.Extensions
{
    public static class UserExtension
    {
        public static void BuildUserModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(i => i.Id);

                entity.Property(p => p.Id).ValueGeneratedOnAdd();

                entity.Property(p => p.FirstName).HasMaxLength(50).IsRequired();

                entity.Property(p => p.LastName).HasMaxLength(50).IsRequired();

                entity.Property(p => p.Email).HasMaxLength(50).IsRequired();

                entity.Property(p => p.Phone).HasMaxLength(15).IsRequired();

                entity.Property(p => p.DataBirth).IsRequired();
            });
        }
    }
}