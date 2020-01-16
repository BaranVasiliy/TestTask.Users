using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Users.BLL.DTOs.Users;

namespace TestTask.Users.BLL.Services.Contracts
{
    public interface IUserService
    {
        Task<List<GetUserDto>> GetUsersAsync();
        Task<GetUserDto> GetUserAsync(int id);
        Task<GetUserDto> CreateUserAsync(CreateUserDto item);
        Task<GetUserDto> UpdateUserAsync(GetUserDto item);
        Task DeleteUserAsync(GetUserDto item);
    }
}