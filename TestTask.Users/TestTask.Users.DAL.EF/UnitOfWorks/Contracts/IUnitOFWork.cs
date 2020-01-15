using System;
using System.Threading.Tasks;
using TestTask.Users.DAL.EF.Entities;
using TestTask.Users.DAL.EF.Repositories.Contracts;

namespace TestTask.Users.DAL.EF.Interfaces
{
    public interface IUnitOFWork : IDisposable
    {
        IUserRepository UserRepository { get; }

        Task SaveAsync();
    }
}