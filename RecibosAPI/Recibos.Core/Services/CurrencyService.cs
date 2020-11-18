using Recibos.Core.Entities;
using Recibos.Core.Exceptions;
using Recibos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recibos.Core.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CurrencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }        

        public IEnumerable<Currency> GetCurrencies()
        {
            var result = _unitOfWork.CurrencyRepository.GetAll();
            return result;
        }
        public async Task<Currency> GetCurrency(int id)
        {
            var result = await _unitOfWork.CurrencyRepository.GetById(id);
            return result;
        }
        public async Task AddCurrency(Currency currency)
        {
            ValidationRules(currency);
            await _unitOfWork.CurrencyRepository.Add(currency);
        }
        public async Task<bool> UpdateCurrency(Currency currency)
        {
            ValidationRules(currency);
            _unitOfWork.CurrencyRepository.Update(currency);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteCurrency(int id)
        {
            await _unitOfWork.CurrencyRepository.Delete(id);
            return true;
        }

        void ValidationRules(Currency currency)
        {
            if (String.IsNullOrEmpty(currency.Acronym))
            {
                throw new BusinessException("El campo acrónimo es requerido.");
            }

            if (currency.Acronym.Length > 3)
            {
                throw new BusinessException("El campo acrónimo excede el limite de 3 caracteres.");
            }
        }
    }
}
