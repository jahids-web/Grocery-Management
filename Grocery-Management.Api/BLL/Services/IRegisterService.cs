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
    public interface IRegisterService
    {
        Task<Register> InsertAsync(RegisterViewModel request);

        Task<List<Register>> GetAllAsync();

        Task<Register> GetAAsync(int userId);

        Task<Register> UpdateAsync(int userId, RegisterViewModel request);

        Task<Register> DeleteAsync(int userId);
    }

    public class RegisterService : IRegisterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Register> InsertAsync(RegisterViewModel request)
        {
            throw new NotImplementedException();
        }

        public Task<Register> GetAAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Register>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Register> UpdateAsync(int userId, RegisterViewModel request)
        {
            throw new NotImplementedException();
        }

        public Task<Register> DeleteAsync(int userId)
        {
            throw new NotImplementedException();
        }

    }
}
