using EComPayApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Persistence.Configurations
{
    public class BranchConfiguration:IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branches");

            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Address)
                   .WithMany(a => a.Branches)
                   .HasForeignKey(b => b.AddressId)
                   .OnDelete(DeleteBehavior.Cascade); 
            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(b => b.Description)
                   .HasMaxLength(500);

            builder.Property(b => b.Phone)
                   .HasMaxLength(15);

            builder.Property(b => b.Email)
                   .HasMaxLength(100);

            builder.HasMany(b => b.Products)
                   .WithOne(p => p.Branch)
                   .HasForeignKey(p => p.BranchId)
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
