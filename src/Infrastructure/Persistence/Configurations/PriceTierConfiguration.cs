using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Infrastructure.Persistence.Configurations
{
    public class PriceTierConfiguration: IEntityTypeConfiguration<PriceTier>
    {
       
        public void Configure(EntityTypeBuilder<PriceTier> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.Customers)
                .WithOne(x => x.PriceTier)
                .HasForeignKey(z => z.PriceTierId);

            builder.Property(e => e.Name).HasMaxLength(50);

        }
    }

}
