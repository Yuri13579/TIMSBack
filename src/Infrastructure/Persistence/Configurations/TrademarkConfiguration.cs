using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Infrastructure.Persistence.Configurations
{
    class TrademarkConfiguration : IEntityTypeConfiguration<Trademark>
    {
        public void Configure(EntityTypeBuilder<Trademark> builder)
        {
            builder.HasKey(e => e.TrademarkId);

            builder.Property(e => e.TrademarkName).HasMaxLength(50);

        }

    }

}
