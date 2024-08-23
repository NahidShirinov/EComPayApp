using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using EComPayApp.Persistence.Contexts;


namespace EComPayApp.Persistence.Repositories
{

    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(EComPayAppDbContext context) : base(context)
        {
        }
    }
}
