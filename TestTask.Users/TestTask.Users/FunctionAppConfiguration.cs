using System;
using System.Collections.Generic;
using System.Text;
using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Users.BLL.Services;
using TestTask.Users.Commands;
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
                    //serviceCollection.AddTransient<IUserService, UserService>();
                    commandRegistry.Register<GetUserCommandHandlers>();
                })
                .Functions(functions => functions
                    .HttpRoute("v1/GetUsers", route => route
                        .HttpFunction<GetUsersCommand>()
                    )
                );

        }
    }
}
