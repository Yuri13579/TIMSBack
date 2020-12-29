using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Infrastructure.Persistence.Configurations
{
    public class SupplierPaymentHistoryConfiguration : IEntityTypeConfiguration<SupplierPaymentHistory>
    {
        public void Configure(EntityTypeBuilder<SupplierPaymentHistory> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Supplier)
                .WithMany(x => x.SupplierPaymentHistories)
                .HasForeignKey(z => z.SupplierId);

            builder.Property(e => e.Name).HasMaxLength(50);

        }
    }


}
