using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using EComPayApp.Persistence.Contexts;
using EComPayApp.Persistence.Repositories;

namespace ECommerceBackend.Persistence.Repositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(EComPayAppDbContext context) : base(context)
        {
        }
    }
}
