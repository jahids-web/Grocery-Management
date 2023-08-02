using BLL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IRegisterService
    {
        Task<Register> InsertAsync(RegisterViewModel viewModel);
    }

    public class RegisterService : IRegisterService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RegisterService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Register> InsertAsync(RegisterViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
