﻿using EComPayApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.FirstName)
               .IsRequired()
               .HasMaxLength(50);
        builder.Property(c => c.LastName)
               .IsRequired()
               .HasMaxLength(50);
        builder.Property(c => c.Email)
               .IsRequired()
               .HasMaxLength(100);
        builder.HasIndex(c => c.Email)
                .IsUnique();
        builder.HasMany(c => c.Orders)
               .WithOne(o => o.Customer)
               .HasForeignKey(o => o.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
