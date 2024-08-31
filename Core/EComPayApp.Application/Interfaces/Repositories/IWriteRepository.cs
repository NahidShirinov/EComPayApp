using EComPayApp.Domain.Entities;
using EComPayApp.Domain.Entities.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        bool Remove(T entity);
        bool RemoveRange(List<T> entities);
        Task<bool> RemoveAsync(string Id);
        bool Update(T entity);
        Task<int> SaveAsync(CancellationToken cancellationToken);
        Task UpdateAsync(Product product);
        Task<bool> GetByIdAsync(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Customer customer);
        Task SaveAsync();
        void DeleteAsync(Order order);
        void DeleteAsync(OrderItem orderItem);
        Task DeleteAsync(About about);
        Task UpdateAsync(About about);
        Task DeleteAsync(Contact contact);
        Task UpdateAsync(Contact contact);
    }
}
