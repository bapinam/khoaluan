using KhoaLuan.Data.Entities;
using KhoaLuan.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Configurations
{
    public class BillCF : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bills");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.CodeBill).IsRequired().HasMaxLength(20);
            builder.Property(x => x.StorageCode).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Tax).HasDefaultValue(null);
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.PurchaseDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.AmountPaid).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.TotalMoney).HasDefaultValue(0);
            builder.Property(x => x.PaymentStatus).IsRequired().HasDefaultValue(PaymentStatus.Unpaid);

            builder.HasOne(x => x.Supplier).WithMany(x => x.Bills).HasForeignKey(x => x.IdSupplier);
            builder.HasOne(x => x.OrderPlan).WithMany(x => x.Bills).HasForeignKey(x => x.IdPlan);
            builder.HasOne(x => x.Creator).WithMany(x => x.Bills).HasForeignKey(x => x.IdCreator);
        }
    }
}