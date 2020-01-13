using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.DAL.EF.Entities;

namespace TestTask.Users.BLL.Configurations.MapperProfiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, GetUsersDTO>();
        }
    }
}