using KredoBank.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace KredoBank.Infrastructure.SeedWork
{
    public class GenericRepository<T, K> : IGenericRepository<T> where T : class
            where K : DbContext
    {
        private readonly K _context;
        public GenericRepository(K context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(entity, cancellationToken);
        }

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(where, cancellationToken: cancellationToken);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
