using Recibos.Core.Entities;
using Recibos.Core.Exceptions;
using Recibos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recibos.Core.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Supplier> GetSuppliers()
        {
            var result = _unitOfWork.SupplierRepository.GetAll();
            return result;
        }
        public async Task<Supplier> GetSupplier(int id)
        {
            var result = await _unitOfWork.SupplierRepository.GetById(id);
            return result;
        }
        public async Task AddSupplier(Supplier supplier)
        {
            ValidationRules(supplier);
            await _unitOfWork.SupplierRepository.Add(supplier);
        }  
        public async Task<bool> UpdateSupplier(Supplier supplier)
        {
            ValidationRules(supplier);
            _unitOfWork.SupplierRepository.Update(supplier);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteSupplier(int id)
        {
            await _unitOfWork.SupplierRepository.Delete(id);
            return true;
        }

        void ValidationRules(Supplier supplier) 
        {
            if (supplier != null)
            {
                if (String.IsNullOrEmpty(supplier.Name))
                {
                    throw new BusinessException("El campo nombre es requerido.");
                }

                if (supplier.Name.Length > 100)
                {
                    throw new BusinessException("El campo nombre excede el limite de 100 caracteres.");
                }
            }            
        }
    }
}
