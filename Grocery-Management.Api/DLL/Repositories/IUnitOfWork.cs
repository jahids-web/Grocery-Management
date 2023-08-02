using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IUnitOfWork
    {
        ILoginRepository LoginRepository { get; }
        IRegisterRepository RegisterRepository { get; }

        Task<bool> SavaChangesAsync();
    }
}
