using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.ProductId);

            builder.HasOne(e => e.ProductDescription)
                .WithOne(x => x.Product)
                .HasForeignKey<ProductDescription>(z => z.ProductId);

            builder.Property(e => e.Name).HasMaxLength(50);
            
        }
    }

}
