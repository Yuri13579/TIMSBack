using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.CategoryCustomer)
                .WithMany(x => x.Customers)
                .HasForeignKey(z => z.CategoryCustomerId);

            builder.HasOne(e => e.PriceTier)
                .WithMany(x => x.Customers)
                .HasForeignKey(z => z.PriceTierId);

            builder.HasOne(e => e.TermsOfPayment)
                .WithMany(x => x.Customers)
                .HasForeignKey(z => z.TermsOfPaymentId);

            builder.HasMany(e => e.CustomerPaymentHistories)
                .WithOne(x => x.Customer)
                .HasForeignKey(z => z.CustomerId);
            
            builder.Property(e => e.Name).HasMaxLength(50);

        }
    }

}
