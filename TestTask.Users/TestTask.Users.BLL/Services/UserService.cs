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
        public async Task<List<GetUserDTO>> GetUsersAsync()
        {
            IEnumerable<User> users = await _unitOfWork.UserRepository.GetAll();

            return _mapper.Map<List<GetUserDTO>>(users);
        }

        public async Task<GetUserDTO> GetUserAsync(int id)
        {
            User user = await _unitOfWork.UserRepository.GetById(id);

            return _mapper.Map<GetUserDTO>(user);
        }
    }
}