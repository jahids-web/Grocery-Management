using DLL.DataContext;
using DLL.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface ILoginRepository : IRepositoryBase<Login>
    {
    }

    public class LoginRepository : RepositoryBase<Login>, ILoginRepository 
    { 
        public LoginRepository(ApplicationDbContext context) : base(context) 
        { 
        
        }
    }

}
