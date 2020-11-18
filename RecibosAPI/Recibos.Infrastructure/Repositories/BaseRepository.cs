using Recibos.Core.Interfaces;
using Recibos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Recibos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Recibos.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ReceiptsDBContext _context;
        protected DbSet<T> _entities;
        public BaseRepository(ReceiptsDBContext context) 
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }
        public void Update(T entity)
        {
            _entities.Update(entity);            
        }
        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }
    }
}
