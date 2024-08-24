using EComPayApp.Domain.Entities.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Interfaces.Repositories.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IReadRepository<T> ReadRepository<T>() where T : BaseEntity;
        IWriteRepository<T> WriteRepository<T>() where T : BaseEntity;

        Task<int> CommitAsync();
    }


}
