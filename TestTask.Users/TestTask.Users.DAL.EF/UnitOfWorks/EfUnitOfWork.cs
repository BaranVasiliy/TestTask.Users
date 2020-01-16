using System;
using System.Threading.Tasks;
using TestTask.Users.DAL.EF.DataContext;
using TestTask.Users.DAL.EF.Interfaces;
using TestTask.Users.DAL.EF.Repositories;
using TestTask.Users.DAL.EF.Repositories.Contracts;

namespace TestTask.Users.DAL.EF.UnitOfWorks
{
    public class EfUnitOfWork : IUnitOFWork
    {
        private UserDbContext _context;

        private IUserRepository _userRepository;

        public EfUnitOfWork(UserDbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ?? (_userRepository = new UserRepository(_context));
            }
        }

        public async Task SaveAsync()
        { 
            await _context.SaveChangesAsync();
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}