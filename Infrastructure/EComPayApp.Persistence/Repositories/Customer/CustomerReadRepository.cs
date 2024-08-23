using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using EComPayApp.Persistence.Contexts;
using EComPayApp.Persistence.Repositories;

namespace ECommerceBackend.Persistence.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(EComPayAppDbContext context) : base(context)
        {
        }
    }
}
