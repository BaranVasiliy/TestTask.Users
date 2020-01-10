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
                    new User { FirstName = "Name", LastName = "LName", Age = 44},
                    new User { FirstName = "Nam", LastName = "LNam", Age = 44 },
                    new User { FirstName = "Na", LastName = "LNa", Age = 44 }
                );

                context.SaveChanges();
            }
        }
    }
}

