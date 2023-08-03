using BLL.ViewModel;
using DLL.EntityModel;
using DLL.Repositories;
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

        Task<Login> GetAAsync(int userId);

        Task<Login> UpdateAsync(int userId , LoginViewModel request);

        Task<Login> DeleteAsync(int userId);
    }

    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginService(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }

        public Task<Login> InsertAsync(LoginViewModel request)
        {
            throw new NotImplementedException();
        }

        public Task<Login> GetAAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Login>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Login> UpdateAsync(int userId, LoginViewModel request)
        {
            throw new NotImplementedException();
        }

        public Task<Login> DeleteAsync(int userId)
        {
            throw new NotImplementedException();
        }

    }
}
