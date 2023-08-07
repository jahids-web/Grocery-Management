using BLL.ViewModel;
using DLL.EntityModel;
using DLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Exceptions;

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

        public async Task<Login> InsertAsync(LoginViewModel request)
        {
            Login aLogin = new Login();
            aLogin.UserId = request.UserId;
            aLogin.UserName = request.UserName;
            aLogin.Password = request.Password;

            try
            {
                await _unitOfWork.LoginRepository.CreateAsync(aLogin);
                if (await _unitOfWork.SavaChangesAsync())
                {
                    return aLogin;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationValidationException("Insert Has Some Problem" + e);
            }
            return aLogin;
        }

        public async Task<Login> GetAAsync(int userId)
        {
            var login = await _unitOfWork.LoginRepository.FindSingLeAsync(x => x.UserId == userId);
            if (login == null)
            {
                throw new ApplicationValidationException("login Not Found");
            }
            return login;
        }

        public async Task<List<Login>> GetAllAsync()
        {
            return await _unitOfWork.LoginRepository.GetList();
        }

        public async Task<Login> UpdateAsync(int userId, LoginViewModel request)
        {
            var register = await _unitOfWork.RegisterRepository.FindSingLeAsync(x => x.UserId == userId);
            var login = await _unitOfWork.LoginRepository.FindSingLeAsync(x => x.UserId == userId);

            if (login == null)
            {
                throw new ApplicationValidationException("Register Not Found");
            }
            if (!string.IsNullOrWhiteSpace(request.UserName))
            {
                request.UserName = request.UserName;
            }
            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                request.Password = request.Password;
            }
     
            _unitOfWork.LoginRepository.Update(login);
            if (await _unitOfWork.SavaChangesAsync())
            {
                return login;
            }

            throw new ApplicationValidationException("In Update Have Some Problam");
        }

        public async Task<Login> DeleteAsync(int userId)
        {
            var login = await _unitOfWork.LoginRepository.FindSingLeAsync(x => x.UserId == userId);

            if (login == null)
            {
                throw new ApplicationValidationException("Register Not Found");
            }
            _unitOfWork.LoginRepository.Delete(login);

            if (await _unitOfWork.SavaChangesAsync())
            {
                return login;
            }
            throw new ApplicationValidationException("Some Problem for delete data");
        }

    }
}
