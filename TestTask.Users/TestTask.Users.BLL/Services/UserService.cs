using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Users.BLL.DTOs.Users;

namespace TestTask.Users.BLL.Services
{
    public class UserService : IUserService
    {
        public Task<List<GetUsersDTO>> GetUserAsync()
        {
             List<GetUsersDTO> users = new List<GetUsersDTO>();
             users.Add(new GetUsersDTO() { FirstName = "Name", LastName = "Name" });
             return Task.FromResult(users);
        }
    }
}