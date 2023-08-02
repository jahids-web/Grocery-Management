using DLL.DataContext;
using DLL.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IRegisterRepository : IRepositoryBase<Register>
    {

    }

    public class RegisterRepository : RepositoryBase<Register>, IRegisterRepository
    {
        public RegisterRepository(ApplicationDbContext context) : base(context) 
        { 
        
        }
    }

}
