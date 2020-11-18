using Microsoft.EntityFrameworkCore;
using Recibos.Core.Entities;
using Recibos.Core.Interfaces;
using Recibos.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recibos.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ReceiptsDBContext _context;
        public UserRepository(ReceiptsDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var result = await _context.Users.ToListAsync();
            return result;
        }

        public async Task<User> GetUser(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

    }
}
