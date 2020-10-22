using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Infrastructure.Persistence.Configurations
{
    public class CategoryCustomerConfiguration : IEntityTypeConfiguration<CategoryCustomer>
    {
        public void Configure(EntityTypeBuilder<CategoryCustomer> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.HasMany(e => e.Customers)
                .WithOne(x => x.CategoryCustomer)
                .HasForeignKey(z => z.CategoryCustomerId);

            builder.Property(e => e.Name).HasMaxLength(50);

        }
    }

}
