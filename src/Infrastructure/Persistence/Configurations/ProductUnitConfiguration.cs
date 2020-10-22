using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Infrastructure.Persistence.Configurations
{
    public class ProductUnitConfiguration : IEntityTypeConfiguration<ProductUnit>
    {
        public void Configure(EntityTypeBuilder<ProductUnit> builder)
        {
            builder.HasKey(e => e.ProductUnitId);

            builder.HasMany(e => e.Products)
                .WithOne(x => x.ProductUnit)
                .HasForeignKey(z => z.ProductUnitId);

            builder.Property(e => e.UnitName).HasMaxLength(50);
            
        }
    }
 
}
