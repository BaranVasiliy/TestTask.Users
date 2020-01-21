﻿using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Net.Http;
using TestTask.Users.Commands;
using TestTask.Users.DAL.EF.DataContext;
using TestTask.Users.Extensions;
using TestTask.Users.Queries;

namespace TestTask.Users
{
    public class FunctionAppConfiguration : IFunctionAppConfiguration
    {
        public void Build(IFunctionHostBuilder builder)
        {
            builder
                .Setup((serviceCollection, commandRegistry) =>
                {
                    var configurationBuilder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                    IConfigurationRoot configuration = configurationBuilder.Build();

                    serviceCollection.RegisterMapper();
                    serviceCollection.RegisterRepositories();
                    serviceCollection.RegisterServices(); 
                    serviceCollection.RegisterValidators();

                    serviceCollection.AddDbContext<UserDbContext>(
                        options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")),
                        ServiceLifetime.Transient);

                })
                .Functions(functions => functions
                    .HttpRoute("users", route => route
                        .HttpFunction<GetUsersCommand>(HttpMethod.Get)
                        .HttpFunction<GetUserByIdCommand>("/{id}", HttpMethod.Get)
                        .HttpFunction<CreateUserCommand>(HttpMethod.Post)
                        .HttpFunction<UpdateUserCommand>(HttpMethod.Put)
                        .HttpFunction<DeleteUserCommand>("/{id}", HttpMethod.Delete)
                    )
                );
        }
    }
}