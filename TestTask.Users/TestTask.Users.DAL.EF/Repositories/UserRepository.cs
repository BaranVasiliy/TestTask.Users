using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.Users.DAL.EF.DataContext;
using TestTask.Users.DAL.EF.Entities;
using TestTask.Users.DAL.EF.Repositories.Contracts;

namespace TestTask.Users.DAL.EF.Repositories
{
    public class UserRepository : GenericRepository<int, User>, IUserRepository
    {
        public UserRepository(UserDbContext context) : base(context) { }
    }
}