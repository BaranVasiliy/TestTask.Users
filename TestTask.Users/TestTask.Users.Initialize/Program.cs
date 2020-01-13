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
                    new User { FirstName = "Name", LastName = "LName"},
                    new User { FirstName = "Nam", LastName = "LNam"},
                    new User { FirstName = "Na", LastName = "LNa" }
                );

                context.SaveChanges();
            }
        }
    }
}