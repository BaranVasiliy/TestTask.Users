using AutoMapper;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.Commands;
using TestTask.Users.DAL.EF.Entities;

namespace TestTask.Users
{
    class Map : Profile
    {
        public Map()
        {
            CreateMap<GetUserDto, UpdateUserDto>();
        }
    }
}