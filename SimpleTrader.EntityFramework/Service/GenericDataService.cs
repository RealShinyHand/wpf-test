using SimpleTrader.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.EntityFramework.Service
{
    public class GenericDataService<T> : IDataService<T> where T : class
    {
        private readonly SimpleTraderDBContextFactory _context;
        public GenericDataService(SimpleTraderDBContextFactory context)
        {
            _context = context;
        }

        public async Task<T> Create(T entity)
        {
            using(SimpleTraderDBContext context = _context.CreateDbContext(args:null)) {
                var createdEntity = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return createdEntity.Entity;
            }
            
        }

        public Task<T> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
