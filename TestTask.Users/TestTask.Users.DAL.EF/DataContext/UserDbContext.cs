using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Users.DAL.EF.Entities;
using Microsoft.Extensions.Configuration;
using TestTask.Users.DAL.EF.Extensions;

namespace TestTask.Users.DAL.EF.DataContext
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildUserModel();
        }
    }
}