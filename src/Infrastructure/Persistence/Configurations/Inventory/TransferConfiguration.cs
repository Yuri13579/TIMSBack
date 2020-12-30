using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMSBack.Domain.Entities.Inventory;
using TIMSBack.Domain.Entities.Manufacturing;

namespace TIMSBack.Infrastructure.Persistence.Configurations.Inventory
{
    public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
    {
        public void Configure(EntityTypeBuilder<Transfer> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasOne(x => x.Status)
                .WithMany(y => y.Transfers)
                .HasForeignKey(z => z.StatusId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.QuantityStatus)
                .WithMany(y => y.Transfers)
                .HasForeignKey(z => z.QuantityStatusId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.DestinationWareHouse)
                .WithMany(y => y.DestinationWareHouses)
                .HasForeignKey(z => z.DestinationWareHouseId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.SourceWareHouse)
                .WithMany(y => y.SourceWareHouses)
                .HasForeignKey(z => z.SourceWareHouseId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
