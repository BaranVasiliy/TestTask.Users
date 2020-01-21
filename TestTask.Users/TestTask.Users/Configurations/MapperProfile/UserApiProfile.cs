using AutoMapper;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.Commands;

namespace TestTask.Users.Configurations.MapperProfile
{
    public class UserApiProfile : Profile
    {
        public UserApiProfile()
        {
            CreateMap<CreateUserCommand, CreateUserDto>();

            CreateMap<UpdateUserCommand, UpdateUserDto>();
        }
    }
}