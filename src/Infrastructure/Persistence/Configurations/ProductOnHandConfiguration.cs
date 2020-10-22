using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Infrastructure.Persistence.Configurations
{
    public class ProductOnHandConfiguration : IEntityTypeConfiguration<ProductOnHand>
    {
        public void Configure(EntityTypeBuilder<ProductOnHand> builder)
        {
            builder.HasKey(e => e.ProductOnHandId);

        }

    }

}
