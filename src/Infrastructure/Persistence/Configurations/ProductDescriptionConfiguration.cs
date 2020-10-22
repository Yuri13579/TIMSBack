using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Infrastructure.Persistence.Configurations
{
    public class ProductDescriptionConfiguration : IEntityTypeConfiguration<ProductDescription>
    {
        public void Configure(EntityTypeBuilder<ProductDescription> builder)
        {
            builder.HasKey(e => e.ProductDescriptionId);

            builder.HasIndex(e => e.Barcode).IsUnique();

            builder.Property(e => e.MPE).HasDefaultValue(20);

            builder.Property(e => e.SKU).HasMaxLength(50);

        }

    }

}
