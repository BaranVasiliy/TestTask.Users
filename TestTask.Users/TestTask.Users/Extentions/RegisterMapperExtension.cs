using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Users.BLL.Configurations.MapperProfiles;

namespace TestTask.Users.Extentions
{
    public static class RegisterMapperExtension
    {
        public static void RegisterMapper(this IServiceCollection serviceCollection)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<UsersProfile>();
            });

            serviceCollection.AddSingleton(s => mapperConfiguration.CreateMapper());
        }
    }
}
