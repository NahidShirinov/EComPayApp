
using EComPayApp.Application.Features.CQRS.Queries.Address.GetAddress;
using EComPayApp.Application.Interfaces.Repositories.IUnitOfWork;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Persistence.Contexts;
using EComPayApp.Persistence.Repositories;
using EComPayApp.Persistence.UoW;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            // Register the DbContext
            services.AddDbContext<EComPayAppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.ConnectionString);
            });

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }

}
