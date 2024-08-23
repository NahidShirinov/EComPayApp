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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(90);

            builder.Property(a => a.State)
                .HasMaxLength(50);

            builder.Property(a => a.ZipCode)
                .HasMaxLength(20);

            builder.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasMany(a => a.Branches)
                .WithOne(b => b.Address)
                .HasForeignKey(b => b.AddressId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
