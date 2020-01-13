using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.DAL.EF.Entities;
using TestTask.Users.DAL.EF.Interfaces;

namespace TestTask.Users.BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOFWork _database { get; set; }

        public UserService(IUnitOFWork database)
        {
            _database = database;
        }
        public Task<List<GetUsersDTO>> GetUsersAsync()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, GetUsersDTO>()).CreateMapper();
            return Task.FromResult(mapper.Map<IEnumerable<User>, List<GetUsersDTO>>(_database.Users.GetAll()));
        }

        public Task<GetUsersDTO> GetUserAsync(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Не установлено id телефона", new Exception(""));
            var user = _database.Users.Get(Id.Value);
            if (user == null)
                throw new ValidationException("Телефон не найден", new Exception(""));

            return Task.FromResult(new GetUsersDTO {UserId = user.UserId, FirstName = user.FirstName, LastName = user.LastName});
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

     
    }
}