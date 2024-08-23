using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Application;
using EComPayApp.Domain.Entities;
using EComPayApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Persistence.Repositories
{
    public class AddressWriteRepository : WriteRepository<Address>, IAddressWriteRepository
    {
        public AddressWriteRepository(EComPayAppDbContext context) : base(context)
        {
        }
    }
}
