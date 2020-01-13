using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Users.BLL.Services;
using TestTask.Users.Commands;
using TestTask.Users.DAL.EF.DataContext;
using TestTask.Users.DAL.EF.Entities;
using TestTask.Users.DAL.EF.Interfaces;
using TestTask.Users.DAL.EF.Repositories;
using TestTask.Users.DAL.EF.UnitOfWorks;
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
                    serviceCollection.AddDbContext<UserDbContext>(
                        options => options.UseSqlServer(("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MyDatabase;Integrated Security=True")),
                        ServiceLifetime.Transient);

                    commandRegistry.Register<GetUsersCommandHandlers>();
                })
                .Functions(functions => functions
                    .HttpRoute("v1/GetUsers", route => route
                        .HttpFunction<GetUsersCommand>()
                    )
                );
            builder
                .Functions(functions => functions
                    .HttpRoute("v1/GetUser", route => route
                        .HttpFunction<GetUserCommand>()));
        }
    }
}