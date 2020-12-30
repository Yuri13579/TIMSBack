using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIMSBack.Domain.Entities;
using TIMSBack.Domain.Entities.Manufacturing;

namespace TIMSBack.Infrastructure.Persistence.Configurations.Manufacturing
{
    public class WorkOrderConfiguration : IEntityTypeConfiguration<WorkOrder>
    {
        public void Configure(EntityTypeBuilder<WorkOrder> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Name).HasMaxLength(50);

            
        }
    }

}
