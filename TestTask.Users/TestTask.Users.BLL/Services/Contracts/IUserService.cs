using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Users.BLL.DTOs.Pagination;
using TestTask.Users.BLL.DTOs.Users;

namespace TestTask.Users.BLL.Services.Contracts
{
    public interface IUserService
    {
        Task<List<GetUserDTO>> GetUsersAsync();

        Task<GetUserDTO> GetUserAsync(int id);

        Task<GetUserDTO> CreateUserAsync(CreateUserDto item);

        Task<GetUserDTO> UpdateUserAsync(UpdateUserDto item);

        Task<List<GetUserDTO>> GetUserByCityAsync(string city);

        Task DeleteUserAsync(GetUserDTO item);

        PagedResultDto<T> GetPaged<T>(IEnumerable<T> query,
            int page, int pageSize) where T : class;
    }
}