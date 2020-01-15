using System.Configuration;
using System.IO;
using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using TestTask.Users.BLL.Services;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Commands;
using TestTask.Users.DAL.EF.DataContext;
using TestTask.Users.DAL.EF.Interfaces;
using TestTask.Users.DAL.EF.UnitOfWorks;
using TestTask.Users.Extentions;
using TestTask.Users.Handlers;

namespace TestTask.Users
{
    public class FunctionAppConfiguration : IFunctionAppConfiguration
    {
        public void Build(IFunctionHostBuilder builder)
        {
            builder
                .Setup((serviceCollection, commandRegistry) =>
                {
                    serviceCollection.AddTransient<IUnitOFWork, EfUnitOfWork>();
                    serviceCollection.AddTransient<IUserService, UserService>();
                    serviceCollection.RegisterMapper();
                    serviceCollection.AddDbContext<UserDbContext>(
                        options => options.UseSqlServer(GetConnectionString()),
                        ServiceLifetime.Transient);

                    commandRegistry.Register<GetUsersCommandHandlers>();
                })
                .Functions(functions => functions
                    .HttpRoute("users", route => route
                        .HttpFunction<GetUsersCommand>("",HttpMethod.Get)
                        .HttpFunction<GetUserCommand>("/{id}", HttpMethod.Get)
                    )
                );
        }

        public string GetConnectionString()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configurationBuilder.Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            return connectionString;
        }
    }
}