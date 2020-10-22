using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Infrastructure.Persistence.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(e => e.ProductCategoryId);

            builder.HasOne(e => e.Product)
                .WithMany(x => x.ProductCategories)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(e => e.Category)
                .WithMany(x => x.ProductCategories)
                .HasForeignKey(x => x.CategoryId);

        }

    }
}



