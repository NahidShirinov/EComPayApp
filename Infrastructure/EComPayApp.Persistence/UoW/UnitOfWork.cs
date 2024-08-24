using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Application.Interfaces.Repositories.IUnitOfWork;
using EComPayApp.Domain.Entities.Comman;
using EComPayApp.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
namespace EComPayApp.Persistence.UoW
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly EComPayAppDbContext _context;
        private readonly IServiceProvider _serviceProvider;
        public UnitOfWork(EComPayAppDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }
        public IReadRepository<T> ReadRepository<T>() where T : BaseEntity
        {
            return _serviceProvider.GetService<IReadRepository<T>>();
        }

        public IWriteRepository<T> WriteRepository<T>() where T : BaseEntity
        {
            return _serviceProvider.GetService<IWriteRepository<T>>();
        }
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
