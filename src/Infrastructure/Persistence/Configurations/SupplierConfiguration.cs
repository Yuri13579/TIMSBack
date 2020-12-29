using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Infrastructure.Persistence.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.CategorySupplier)
                .WithMany(x => x.Suppliers)
                .HasForeignKey(z => z.CategorySupplierId);
            

            builder.HasOne(e => e.TermsOfPayment)
                .WithMany(x => x.Suppliers)
                .HasForeignKey(z => z.TermsOfPaymentId);

            builder.HasMany(e => e.SupplierPaymentHistories)
                .WithOne(x => x.Supplier)
                .HasForeignKey(z => z.SupplierId);

            builder.Property(e => e.Name).HasMaxLength(50);

        }
    }
    
    
}
