using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Users.BLL.DTOs;
using TestTask.Users.BLL.DTOs.Pagination;
using TestTask.Users.BLL.DTOs.Users;
using TestTask.Users.BLL.Services.Contracts;
using TestTask.Users.DAL.EF.Entities;
using TestTask.Users.DAL.EF.Interfaces;

namespace TestTask.Users.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOFWork _unitOfWork;

        private readonly IMapper _mapper;

        public UserService(IUnitOFWork unitOfWork, IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetUserDTO>> GetUsersAsync()
        {
            IEnumerable<User> users = await _unitOfWork.UserRepository.GetAllAsync();

            return _mapper.Map<List<GetUserDTO>>(users);
        }

        public async Task<GetUserDTO> GetUserAsync(int id)
        {
            User user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            return _mapper.Map<GetUserDTO>(user);
        }

        public async Task<List<GetUserDTO>> GetUserByCityAsync(string city)
        {
            List<User> user = await _unitOfWork.UserRepository.GetUserByCity(city);

            return _mapper.Map<List<GetUserDTO>>(user);
        }
        public async Task<GetUserDTO> CreateUserAsync(CreateUserDto item)
        {
            User newUser = _mapper.Map<User>(item);

            _unitOfWork.UserRepository.Add(newUser);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<GetUserDTO>(newUser);
        }

        public async Task<GetUserDTO> UpdateUserAsync(UpdateUserDto item)
        {
            User user = await _unitOfWork.UserRepository.GetByIdAsync(item.Id);

            User itemToUpdate = _mapper.Map(item, user);

            _unitOfWork.UserRepository.Update(itemToUpdate);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<GetUserDTO>(itemToUpdate);
        }

        public async Task DeleteUserAsync(GetUserDTO item)
        {
            User user = await _unitOfWork.UserRepository.GetByIdAsync(item.Id);

            User itemToRemove = _mapper.Map(item,user);

            _unitOfWork.UserRepository.Remove(itemToRemove);

            await _unitOfWork.SaveAsync();
        }

        public PagedResultDto<T> GetPaged<T>(IEnumerable<T> query,
            int page, int pageSize) where T : class
        {
            PagedResultDto<T> result = new PagedResultDto<T>
            {
                CurrentPage = page, PageSize = pageSize, RowCount = query.Count()
            };


            double pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            int skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}