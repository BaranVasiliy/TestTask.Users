using Microsoft.EntityFrameworkCore;
using TestTask.Users.DAL.EF.Entities;
using TestTask.Users.DAL.EF.Extensions;

namespace TestTask.Users.DAL.EF.DataContext
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildUserModel();

            modelBuilder.BuildAddressModel();
        }
    }
}