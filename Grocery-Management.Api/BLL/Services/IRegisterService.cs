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
    public interface IRegisterService
    {
        Task<Register> InsertAsync(RegisterViewModel requestData);

        Task<List<Register>> GetAllAsync();

        Task<Register> GetAAsync(int userId);

        Task<Register> UpdateAsync(int userId, RegisterViewModel requestData);

        Task<Register> DeleteAsync(int userId);
    }

    public class RegisterService : IRegisterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Register> InsertAsync(RegisterViewModel requestData)
        {
            Register aRegister = new Register();
            aRegister.UserId = requestData.UserId;
            aRegister.UserName = requestData.UserName;
            aRegister.Email = requestData.Email;
            aRegister.Address = requestData.Address;
            aRegister.Password = requestData.Password;

            try
            {
                await _unitOfWork.RegisterRepository.CreateAsync(aRegister);
                if (await _unitOfWork.SavaChangesAsync())
                {
                    return aRegister;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationValidationException("Insert Has Some Problem" + e);
            }
            return aRegister;
        }

        public async Task<Register> GetAAsync(int userId)
        {
            var register = await _unitOfWork.RegisterRepository.FindSingLeAsync(x => x.UserId == userId);
            if(register == null)
            {
                throw new ApplicationValidationException("Register Not Found");
            }
            return register;
        }

        public async Task<List<Register>> GetAllAsync()
        {
            return await _unitOfWork.RegisterRepository.GetList();
        }

        public async Task<Register> UpdateAsync(int userId, RegisterViewModel requestData)
        {
            var register = await _unitOfWork.RegisterRepository.FindSingLeAsync(x => x.UserId == userId);

            if(register == null)
            {
                throw new ApplicationValidationException("Register Not Found");
            }
            if (!string.IsNullOrWhiteSpace(requestData.UserName))
            {
                requestData.UserName = requestData.UserName;
            }
            if (!string.IsNullOrWhiteSpace(requestData.Email))
            {
                requestData.Email = requestData.Email;
            }
            if (!string.IsNullOrWhiteSpace(requestData.Password))
            {
                requestData.Password = requestData.Password;
            }
            requestData.Address = requestData.Address;

            _unitOfWork.RegisterRepository.Update(register);
            if (await _unitOfWork.SavaChangesAsync())
            {
                return register;
            }

            throw new ApplicationValidationException("In Update Have Some Problam");
        }

        public async Task<Register> DeleteAsync(int userId)
        {
            var register = await _unitOfWork.RegisterRepository.FindSingLeAsync(x =>x.UserId == userId);

            if(register == null)
            {
                throw new ApplicationValidationException("Register Not Found");
            }
            _unitOfWork.RegisterRepository.Delete(register);

            if(await _unitOfWork.SavaChangesAsync())
            {
               return register;
            }
            throw new ApplicationValidationException("Some Problem for delete data");
        }

    }
}
