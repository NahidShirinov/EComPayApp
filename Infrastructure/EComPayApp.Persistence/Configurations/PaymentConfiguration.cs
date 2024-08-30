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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
           
            builder.HasKey(p => p.OrderId);

            
            builder.Property(p => p.Amount)
                   .IsRequired()
                   .HasColumnType("float"); 

            
            builder.Property(p => p.PaymentMethod)
                   .IsRequired()
                   .HasMaxLength(100); 
           
            builder.Property(p => p.Status)
                   .IsRequired();

            
            builder.HasOne(p => p.Order)
                   .WithMany(o => o.Payments)
                   .HasForeignKey(p => p.OrderId); 
        }
    }
    
    }

