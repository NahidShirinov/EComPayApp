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
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            
            builder.ToTable("Contacts");

            // Primary Key
            builder.HasKey(c => c.Id);

            // Properties
            builder.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.WorkingHours)
                .HasMaxLength(100);

            builder.Property(c => c.MapLocation)
                .HasMaxLength(500);

            // Indexlər
            builder.HasIndex(c => c.Email)
                .IsUnique(); // Email unikal olmalıdır
        }
    
    }
}
