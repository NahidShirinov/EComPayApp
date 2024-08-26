using EComPayApp.Domain.Entities.Comman;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EComPayApp.Persistence.Contexts;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;

namespace EComPayApp.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly EComPayAppDbContext _context;

        public WriteRepository(EComPayAppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public Task DeleteAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            // ID ilə entiti-ni tapmaq üçün `Table` istifadə edilir.
            return await Table.FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task<bool> GetByIdAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            T entity = await Table.FirstOrDefaultAsync(e => e.Id == id);
            return entity != null && Remove(entity);
        }

        public Task<bool> RemoveAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public async Task<int> SaveAsync(CancellationToken cancellationToken)
            => await _context.SaveChangesAsync(cancellationToken);

        public bool Update(T entity)
        {
            EntityEntry<T> entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            EntityEntry<T> entityEntry = Table.Update(entity);
            return await Task.FromResult(entityEntry.State == EntityState.Modified);
        }

        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        Task IWriteRepository<T>.SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
