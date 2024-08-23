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
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(pi => pi.ProductId);

            
            builder.Property(pi => pi.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(2048); 

           
            builder.Property(pi => pi.IsMainImage)
                   .IsRequired();

           
            builder.HasOne(pi => pi.Product)
                   .WithMany(p => p.Images)
                   .HasForeignKey(pi => pi.ProductId);
        }
    }
}
    

