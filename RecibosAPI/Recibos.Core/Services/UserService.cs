using Recibos.Core.Entities;
using Recibos.Core.Exceptions;
using Recibos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Recibos.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> GetUsers()
        {
            var result = _unitOfWork.UserRepository.GetAll();
            return result;
        }
        public async Task<User> GetUser(int id)
        {
            var result = await _unitOfWork.UserRepository.GetById(id);
            return result;
        }        
        public async Task AddUser(User user)
        {
            ValidationRules(user);
            await _unitOfWork.UserRepository.Add(user);
        }

        public async Task<bool> UpdateUser(User user)
        {
            ValidationRules(user);
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteUser(int id)
        {
            await _unitOfWork.UserRepository.Delete(id);
            return true;
        }

        void ValidationRules(User user)
        {
            if (String.IsNullOrEmpty(user.Email))
            {
                throw new BusinessException("El campo Email es requerido.");
            }

            if (String.IsNullOrEmpty(user.Name))
            {
                throw new BusinessException("El campo Nombres es requerido.");
            }

            if (String.IsNullOrEmpty(user.LastName))
            {
                throw new BusinessException("El campo Apellidos es requerido.");
            }
        }
    }
}
