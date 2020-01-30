using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Users.BLL.Configurations.MapperProfiles;
using TestTask.Users.BLL.Services;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.Commands;
using TestTask.Users.Configurations.MapperProfile;
using TestTask.Users.DAL.EF.Interfaces;
using TestTask.Users.DAL.EF.UnitOfWorks;
using TestTask.Users.Validations;

namespace TestTask.Users.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static void RegisterRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUnitOFWork, EfUnitOfWork>();
        }

        public static void RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IServiceBusPersistentConnection, ServiceBusPersistentConnection>();
            serviceCollection.AddTransient<IServiceBusClient, ServiceBusClient>();
        }

        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateUserCommand>, CreateUserValidator>();
        }

        public static void RegisterMapper(this IServiceCollection serviceCollection)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<UsersProfile>();

                c.AddProfile<UserApiProfile>();
            });

            serviceCollection.AddSingleton(s => mapperConfiguration.CreateMapper());
        }
    }
}