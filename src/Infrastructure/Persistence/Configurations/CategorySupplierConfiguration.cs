using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Infrastructure.Persistence.Configurations
{
    public class CategorySupplierConfiguration : IEntityTypeConfiguration<CategorySupplier>
    {
        public void Configure(EntityTypeBuilder<CategorySupplier> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.Suppliers)
                .WithOne(x => x.CategorySupplier)
                .HasForeignKey(z => z.CategorySupplierId);

            builder.Property(e => e.Name).HasMaxLength(50);

        }
    }


}
