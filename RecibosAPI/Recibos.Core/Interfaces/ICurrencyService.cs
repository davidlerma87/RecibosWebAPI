using Recibos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recibos.Core.Interfaces
{
    public interface ICurrencyService
    {
        IEnumerable<Currency> GetCurrencies();

        Task<Currency> GetCurrency(int id);

        Task AddCurrency(Currency currency);

        Task<bool> UpdateCurrency(Currency currency);

        Task<bool> DeleteCurrency(int id);
    }
}
