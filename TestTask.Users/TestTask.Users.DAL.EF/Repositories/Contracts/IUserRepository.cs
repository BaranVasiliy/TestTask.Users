using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Users.DAL.EF.Entities;

namespace TestTask.Users.DAL.EF.Repositories.Contracts
{
    public interface IUserRepository : IGenericRepository<int, User>
    {
        Task<List<User>> GetUserByCity(string city);
    }
}