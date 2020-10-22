using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Infrastructure.Persistence.Configurations
{
    public class ProductTrademarkConfiguration : IEntityTypeConfiguration<ProductTrademark>
    {
        public void Configure(EntityTypeBuilder<ProductTrademark> builder)
        {
            builder.HasKey(e => e.ProductTrademarkId);

            builder.HasOne(e => e.Product)
                .WithMany(x => x.ProductTrademarks)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(e => e.Trademark)
                .WithMany(x => x.ProductTrademarks)
                .HasForeignKey(x => x.TrademarkId);

        }

    }

}
