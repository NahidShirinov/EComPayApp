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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.CustomerId);

            builder.Property(o => o.Description)
                   .HasMaxLength(500);

            builder.Property(o => o.Address)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(o => o.Discount)
                   .HasColumnType("decimal(18,2)");

            builder.Property(o => o.Status)
                   .IsRequired();

            builder.HasMany(o => o.OrderItems)
                   .WithOne(oi => oi.Order)
                   .HasForeignKey(oi => oi.OrderId);

            builder.HasMany(o => o.Payments)
                   .WithOne(p => p.Order)
                   .HasForeignKey(p => p.OrderId);
        }

    
    
    }
}
