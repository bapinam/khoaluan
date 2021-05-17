using KhoaLuan.Data.Entities;
using KhoaLuan.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Configurations
{
    public class OrderDetailCF : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Amount).HasDefaultValue(0).IsRequired();
            builder.Property(x => x.Unit).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Price).HasDefaultValue(null);
            builder.Property(x => x.Status).HasDefaultValue(false);
            builder.Property(x => x.Note).HasMaxLength(250);
            builder.Property(x => x.EnterAmount).HasDefaultValue(0);
            builder.Property(x => x.IdSupplier).HasDefaultValue(null);
            builder.HasOne(x => x.OrderPlan).WithMany(x => x.OrderDetails).HasForeignKey(x => x.IdOrderPlan);
            builder.HasOne(x => x.Material).WithMany(x => x.OrderDetails).HasForeignKey(x => x.IdMaterials);
            builder.HasOne(x => x.Supplier).WithMany(x => x.OrderDetails).HasForeignKey(x => x.IdSupplier);
        }
    }
}