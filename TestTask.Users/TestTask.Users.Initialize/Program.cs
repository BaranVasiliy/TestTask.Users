using System;
using Microsoft.EntityFrameworkCore;
using TestTask.Users.DAL.EF.DataContext;
using TestTask.Users.DAL.EF.Entities;
using TestTask.Users.Initialize.SQL;

namespace TestTask.Users.Initialize
{
    public class Program
    {
        static void Main(string[] args)
        {
            UsersContextDbFactory usersContext = new UsersContextDbFactory();

            using (UserDbContext context = usersContext.CreateDbContext(null))
            {
                context.Database.Migrate();

                context.Users.AddRange
                (
                    new User { FirstName = "Test", LastName = "Test",Email = "Test",Phone="000000001",DataBirth = DateTime.Now},
                    new User { FirstName = "Test2", LastName = "Test2", Email = "Test2", Phone = "000000002", DataBirth = DateTime.Now },
                    new User { FirstName = "Test3", LastName = "Test3", Email = "Test3", Phone = "000000003", DataBirth = DateTime.Now }
                );

                context.SaveChanges();
            }
        }
    }
}