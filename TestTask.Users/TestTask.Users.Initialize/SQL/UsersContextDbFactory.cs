using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using TestTask.Users.DAL.EF.DataContext;

namespace TestTask.Users.Initialize.SQL
{
    public class UsersContextDbFactory : IDesignTimeDbContextFactory<UserDbContext>
    {
        public UserDbContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configurationBuilder.Build();
            string connectionString = configuration.GetConnectionString("SqlServer");

            DbContextOptionsBuilder<UserDbContext> optionsBuilder = new DbContextOptionsBuilder<UserDbContext>()
                .UseSqlServer(connectionString);

            return new UserDbContext(optionsBuilder.Options);
        }
    }
}