using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Recibos.Core.Entities;

namespace Recibos.Core.Interfaces
{
    public interface ISecurityRepository : IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}
