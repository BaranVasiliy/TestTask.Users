using System;
using TestTask.Users.DAL.EF.Entities;
using TestTask.Users.DAL.EF.Repositories.Contracts;

namespace TestTask.Users.DAL.EF.Interfaces
{
    public interface IUnitOFWork : IDisposable
    {
        IRepository<User> Users { get; }

        void Save();
    }
}