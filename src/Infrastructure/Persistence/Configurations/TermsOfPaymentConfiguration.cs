using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Infrastructure.Persistence.Configurations
{
    public class TermsOfPaymentConfiguration : IEntityTypeConfiguration<TermsOfPayment>
    {
        public void Configure(EntityTypeBuilder<TermsOfPayment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.Customers)
                .WithOne(x => x.TermsOfPayment)
                .HasForeignKey(z => z.TermsOfPaymentId);

            builder.HasMany(e => e.Suppliers)
                .WithOne(x => x.TermsOfPayment)
                .HasForeignKey(z => z.TermsOfPaymentId);

            builder.Property(e => e.Name).HasMaxLength(50);

        }
    }

}
