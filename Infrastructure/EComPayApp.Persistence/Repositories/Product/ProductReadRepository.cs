using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using EComPayApp.Persistence.Contexts;
using EComPayApp.Persistence.Repositories;

namespace ECommerceBackend.Persistence.Repositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(EComPayAppDbContext context) : base(context)
        {
        }
    }
}
