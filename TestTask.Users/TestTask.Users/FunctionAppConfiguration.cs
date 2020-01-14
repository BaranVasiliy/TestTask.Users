using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using TestTask.Users.BLL.Configurations.MapperProfiles;
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
                    serviceCollection.AddTransient<UsersProfile>();
                    serviceCollection.RegisterMapper();
                    serviceCollection.AddDbContext<UserDbContext>(
                        options => options.UseSqlServer(("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MyDatabase;Integrated Security=True")),
                        ServiceLifetime.Transient);

                    commandRegistry.Register<GetUsersCommandHandlers>();
                })
                .Functions(functions => functions
                    .HttpRoute("Get", route => route
                        .HttpFunction<GetUsersCommand>("/Users",HttpMethod.Get)
                        .HttpFunction<GetUserCommand>("/User/{Id}", HttpMethod.Get)
                    )
                );
        }
    }
}