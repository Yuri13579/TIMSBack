using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Infrastructure.Persistence.Configurations
{
    public class CustomerPaymentHistoryConfiguration: IEntityTypeConfiguration<CustomerPaymentHistory>
    {
        public void Configure(EntityTypeBuilder<CustomerPaymentHistory> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Customer)
                .WithMany(x => x.CustomerPaymentHistories)
                .HasForeignKey(z => z.CustomerId);
            
            builder.Property(e => e.Name).HasMaxLength(50);

        }
    }
}
