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
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            
            builder.ToTable("Abouts");

            // Primary Key
            builder.HasKey(a => a.Id);

            // Properties
            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(a => a.Vision)
                .HasMaxLength(500);

            builder.Property(a => a.Mission)
                .HasMaxLength(500);
        }
    
    }
}
