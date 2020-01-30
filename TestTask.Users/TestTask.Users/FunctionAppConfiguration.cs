using System;
using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using TestTask.Users.Commands;
using TestTask.Users.Commands.Bus;
using TestTask.Users.Constants;
using TestTask.Users.DAL.EF.DataContext;
using TestTask.Users.Extensions;
using TestTask.Users.Queries;

namespace TestTask.Users
{
    public class FunctionAppConfiguration : IFunctionAppConfiguration
    {

        private const string TopicName = "testtopic";
        private const string SubscriptionName = "Created_User";
        private const string ServiceBusConnectionName = "serviceBusConnection";

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
                        .HttpFunction<GetUsersQuery>(HttpMethod.Get)
                        .HttpFunction<GetUserByIdQuery>("/{id}", HttpMethod.Get)
                        .HttpFunction<CreateUserCommand>(HttpMethod.Post)
                        .HttpFunction<UpdateUserCommand>(HttpMethod.Put)
                        .HttpFunction<DeleteUserCommand>("/{id}", HttpMethod.Delete)
                        .HttpFunction<GetUserByCityQuery>("/{city}", HttpMethod.Get))

                    .ServiceBus(ServiceBusConnectionName, serviceBus => serviceBus
                        .SubscriptionFunction<AddUserCommand>(TopicName, SubscriptionName)));
        }
    }
}