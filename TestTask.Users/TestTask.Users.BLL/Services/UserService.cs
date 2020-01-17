using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<List<GetUserDto>> GetUsersAsync()
        {
            IEnumerable<User> users = await _unitOfWork.UserRepository.GetAllAsync();

            return _mapper.Map<List<GetUserDto>>(users);
        }

        public async Task<GetUserDto> GetUserAsync(int id)
        {
            User user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            return _mapper.Map<GetUserDto>(user);
        }

        public async Task<GetUserDto> CreateUserAsync(CreateUserDto item)
        {
            User newUser = _mapper.Map<User>(item);

            _unitOfWork.UserRepository.Add(newUser);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<GetUserDto>(newUser);
        }

        public async Task<GetUserDto> UpdateUserAsync(UpdateUserDto item)
        {
            User user = await _unitOfWork.UserRepository.GetByIdAsync(item.Id);

            User itemToUpdate = _mapper.Map(item, user);

            _unitOfWork.UserRepository.Update(itemToUpdate);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<GetUserDto>(itemToUpdate);
        }

        public async Task DeleteUserAsync(GetUserDto item)
        {
            User user = await _unitOfWork.UserRepository.GetByIdAsync(item.Id);

            User itemToRemove = _mapper.Map(item,user);

            _unitOfWork.UserRepository.Remove(itemToRemove);

            await _unitOfWork.SaveAsync();
        }
    }
}