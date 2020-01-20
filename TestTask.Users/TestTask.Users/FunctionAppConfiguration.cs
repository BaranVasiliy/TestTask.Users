using FluentValidation;
using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Net.Http;
using TestTask.Users.BLL.Services;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Commands;
using TestTask.Users.DAL.EF.DataContext;
using TestTask.Users.DAL.EF.Interfaces;
using TestTask.Users.DAL.EF.UnitOfWorks;
using TestTask.Users.Extentions;
using TestTask.Users.Handlers;
using TestTask.Users.Validations;

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
                    serviceCollection.AddTransient<IValidator<CreateUserCommand>, CreateUserValidator>();
                    serviceCollection.AddDbContext<UserDbContext>(
                        options => options.UseSqlServer(GetConnectionString()),
                        ServiceLifetime.Transient);

                    commandRegistry.Register<GetUsersCommandHandlers>();
                    commandRegistry.Register<UpdateUserCommandHandler>();
                })
                .Functions(functions => functions
                    .HttpRoute("users", route => route
                        .HttpFunction<GetUsersCommand>("",HttpMethod.Get)
                        .HttpFunction<GetUserByIdCommand>("/{id}", HttpMethod.Get)
                        .HttpFunction<CreateUserCommand>(HttpMethod.Post)
                        .HttpFunction<UpdateUserCommand>("/update",HttpMethod.Put)
                        .HttpFunction<DeleteUserCommand>("/{id}", HttpMethod.Delete)
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