using DLL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool disposed = false;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private ILoginRepository _loginRepository;
        private IRegisterRepository _registerRepository;

        public ILoginRepository LoginRepository => 
            _loginRepository ?? new LoginRepository(_context);

        public IRegisterRepository RegisterRepository => 
            _registerRepository ?? new RegisterRepository(_context);

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> SavaChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
