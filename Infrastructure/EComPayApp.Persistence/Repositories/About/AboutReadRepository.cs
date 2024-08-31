using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using EComPayApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Persistence.Repositories
{
    public class AboutReadRepository : ReadRepository<About>, IAboutReadRepository
    {
        public AboutReadRepository(EComPayAppDbContext context) : base(context)
        {
        }
    }
}
