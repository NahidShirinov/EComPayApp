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
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => new { oi.ProductId, oi.OrderId }); 

            builder.Property(oi => oi.Quantity)
                   .IsRequired();

            builder.HasOne(oi => oi.Product)
                   .WithMany(p => p.OrderItems)
                   .HasForeignKey(oi => oi.ProductId); 

            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.OrderItems)
                   .HasForeignKey(oi => oi.OrderId); 
        }
    }
    }
