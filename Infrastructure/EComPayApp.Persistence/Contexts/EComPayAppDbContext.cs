using EComPayApp.Domain.Entities;
using EComPayApp.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Persistence.Contexts
{
    public class EComPayAppDbContext:DbContext
    {

        public EComPayAppDbContext(DbContextOptions options):base(options) { }
        DbSet<Address> Addresses { get; set; }
        DbSet<Branch> Branches { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EComPayAppDbContext).Assembly);
        }
    }
}
