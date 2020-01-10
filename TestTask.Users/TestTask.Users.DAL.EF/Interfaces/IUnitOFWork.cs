using System;
using System.Collections.Generic;
using System.Text;
using TestTask.Users.DAL.EF.Entities;

namespace TestTask.Users.DAL.EF.Interfaces
{
    public interface IUnitOFWork : IDisposable
    {
        IRepository<User> Users { get; }
        void Save();
    }
}
