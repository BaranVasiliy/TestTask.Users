using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Users.BLL.DTOs.Users;

namespace TestTask.Users.BLL.Services.Contracts
{
    public interface IUserService
    {
        Task<List<GetUserDTO>> GetUsersAsync();

        Task<GetUserDTO> GetUserAsync(int id);

        Task<GetUserDTO> CreateUserAsync(CreateUserDto item);

        Task<GetUserDTO> UpdateUserAsync(UpdateUserDto item);

        Task DeleteUserAsync(GetUserDTO item);
    }
}