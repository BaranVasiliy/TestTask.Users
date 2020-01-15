using System;
using System.Collections.Generic;
using System.Text;
using TestTask.Users.DAL.EF.Entities;

namespace TestTask.Users.DAL.EF.Repositories.Contracts
{
    public interface IUserRepository : IAsyncRepository<User>
    {
    }
}
