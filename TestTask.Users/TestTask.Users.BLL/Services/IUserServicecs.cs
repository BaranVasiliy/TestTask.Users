using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Users.BLL.DTOs.Users;

namespace TestTask.Users.BLL.Services
{
    public interface IUserService
    {
        Task<List<GetUsersDTO>> GetUserAsync();
    }
}