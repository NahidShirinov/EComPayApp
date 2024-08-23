using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using EComPayApp.Persistence.Contexts;
using EComPayApp.Persistence.Repositories;

namespace ECommerceBackend.Persistence.Repositories
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(EComPayAppDbContext context) : base(context)
        {
        }
    }
}
