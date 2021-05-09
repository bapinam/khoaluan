using KhoaLuan.Data.Entities;
using KhoaLuan.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Configurations
{
    public class OrderPlanCF : IEntityTypeConfiguration<OrderPlan>
    {
        public void Configure(EntityTypeBuilder<OrderPlan> builder)
        {
            builder.ToTable("OrderPlans");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Code).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ExpectedDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Status).HasDefaultValue(StatusOrderPlan.Unfinished);
            builder.Property(x => x.Censorship).HasDefaultValue(false);
            builder.Property(x => x.Note).HasMaxLength(250);
            builder.Property(x => x.IdAuthority).HasDefaultValue(null);

            builder.HasOne(x => x.Creator).WithMany(x => x.OrderPlanCreators).HasForeignKey(x => x.IdCreator);
            builder.HasOne(x => x.Responsible).WithMany(x => x.OrderPlanResponsible).HasForeignKey(x => x.IdResponsible);
            builder.HasOne(x => x.Authority).WithMany(x => x.OrderPlanAuthority).HasForeignKey(x => x.IdAuthority);
        }
    }
}