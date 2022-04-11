using DesafioDevBackEnd.Domain.Entities.Base;
using DesafioDevBackEnd.Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private DbSet<T> _dbSet;

        protected DbSet<T> DbSet
        {
            get => _dbSet ?? (_dbSet = _context.Set<T>());
        }

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            var result = await DbSet.AddAsync(entity);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async void AddRange(List<T> entity)
        {
            await DbSet.AddRangeAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            var result = DbSet.Update(entity);

            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
