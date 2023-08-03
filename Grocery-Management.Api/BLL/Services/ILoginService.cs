using BLL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ILoginService
    {
         
        Task<Login> InsertAsync(LoginViewModel request);
        Task<List<Login>> GetAllAsync();
    }

    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;


        public LoginService(IUnitOfWork _unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Login>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Login> InsertAsync(LoginViewModel request)
        {
            throw new System.NotImplementedException();
        }
    }
}
