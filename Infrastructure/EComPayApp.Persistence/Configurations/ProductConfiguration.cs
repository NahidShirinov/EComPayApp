using EComPayApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           
            builder.HasKey(p => new { p.BranchId, p.CategoryId }); 

            
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);

           
            builder.Property(p => p.Code)
                   .IsRequired()
                   .HasMaxLength(50);

          
            builder.Property(p => p.Description)
                   .HasMaxLength(1000);

           
            builder.Property(p => p.Stock)
                   .IsRequired();

            
            builder.Property(p => p.Price)
                   .IsRequired()
                   .HasColumnType("float");

           
            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId);

            
            builder.HasOne(p => p.Branch)
                   .WithMany(b => b.Products)
                   .HasForeignKey(p => p.BranchId);

           
            builder.HasMany(p => p.Images)
                   .WithOne(i => i.Product)
                   .HasForeignKey(i => i.ProductId);

            
            builder.HasMany(p => p.OrderItems)
                   .WithOne(oi => oi.Product)
                   .HasForeignKey(oi => oi.ProductId);
        }
    
    }
}
