using System;
using System.Collections.Generic;
using System.Text;
using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
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
                    commandRegistry.Register<GetUserCommandHandlers>();
                })
                .Functions(functions => functions
                    .HttpRoute("v1/GetUsers", route => route
                        .HttpFunction<GetUserCommand>()
                    )
                );

        }
    }
}
