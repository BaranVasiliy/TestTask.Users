using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TestTask.Users.DAL.EF.DataContext;
using TestTask.Users.DAL.EF.Entities;
using TestTask.Users.Initialize.SQL;

namespace TestTask.Users.Initialize
{
    public class Program : IDesignTimeDbContextFactory<UserDbContext>
    {
        public UserDbContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configurationBuilder.Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            DbContextOptionsBuilder<UserDbContext> optionsBuilder = new DbContextOptionsBuilder<UserDbContext>()
                .UseSqlServer(connectionString);

            return new UserDbContext(optionsBuilder.Options);
        }

        static void Main(string[] args)
        {
            Program p = new Program();

            using (UserDbContext sc = p.CreateDbContext(null))
            {
                sc.Database.Migrate();

                sc.Users.AddRange
                (
                    new User { FirstName = "Name", LastName = "LName", Age = 44},
                    new User { FirstName = "Nam", LastName = "LNam", Age = 44 },
                    new User { FirstName = "Na", LastName = "LNa", Age = 44 }
                );

                sc.SaveChanges();
            }
        }
    }
}

