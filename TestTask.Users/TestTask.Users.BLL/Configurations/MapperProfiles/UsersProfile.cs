using AutoMapper;
using TestTask.Users.BLL.DTOs.Address;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.DAL.EF.Entities;

namespace TestTask.Users.BLL.Configurations.MapperProfiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<CreateUserDto, User>();

            CreateMap<UpdateUserDto, User>();

            CreateMap<User, GetUserDTO>();

            CreateMap<Address, GetAddressDto>();
        }
    }
}