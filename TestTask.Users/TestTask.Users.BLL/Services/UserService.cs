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
        public Task<List<GetUserDTO>> GetUsersAsync()
        {
            IEnumerable<User> users = _unitOfWork.Users.GetAll();

            return Task.FromResult(_mapper.Map<List<GetUserDTO>>(users));
        }

        public Task<GetUserDTO> GetUserAsync(int Id)
        {
            User user = _unitOfWork.Users.Get(Id);

            return Task.FromResult(new GetUserDTO {UserId = user.UserId, FirstName = user.FirstName, LastName = user.LastName});
        }
    }
}