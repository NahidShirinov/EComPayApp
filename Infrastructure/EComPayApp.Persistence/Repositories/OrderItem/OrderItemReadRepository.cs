using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using EComPayApp.Persistence.Contexts;
using EComPayApp.Persistence.Repositories;

namespace ECommerceBackend.Persistence.Repositories
{
    public class OrderItemReadRepository : ReadRepository<OrderItem>, IOrderItemReadRepository
    {
        public OrderItemReadRepository(EComPayAppDbContext context) : base(context)
        {
        }
    }
}
