
using EComPayApp.Application.Features.CQRS.Queries.Address.GetAddress;
using EComPayApp.Persistence.Contexts;
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
           
            services.AddDbContext<EComPayAppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.ConnectionString);
            });
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAddressHandler).Assembly));

            
        }

    }

}
