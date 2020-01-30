using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Remotion.Linq.Clauses;
using TestTask.Users.DAL.EF.DataContext;
using TestTask.Users.DAL.EF.Entities;
using TestTask.Users.DAL.EF.Repositories.Contracts;

namespace TestTask.Users.DAL.EF.Repositories
{
    public class UserRepository : GenericRepository<int, User>, IUserRepository
    {
        public UserRepository(UserDbContext context) : base(context) { }

        public override async Task<User> GetByIdAsync(int id)
        {
            return await Context.Users.Include(p => p.Address).FirstOrDefaultAsync(t=> t.Id == id);
        }

        public override async Task<IEnumerable<User>> GetAllAsync()
        {
      
            return await Context.Users.Include(p => p.Address).AsNoTracking().ToListAsync();
        }

        public async Task<List<User>> GetUserByCity(string city)
        {
            return await Context.Users.Include(p => p.Address).Where(p => p.Address.City == city).ToListAsync();
        }
    }
}