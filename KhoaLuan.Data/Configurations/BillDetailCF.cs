using KhoaLuan.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Configurations
{
    public class BillDetailCF : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.ToTable("BillDetails");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Unit).IsRequired();
            builder.Property(x => x.Amount).IsRequired().HasDefaultValue(1);
            builder.Property(x => x.Discount).HasDefaultValue(0);
            builder.Property(x => x.TotalPrice).HasDefaultValue(0);

            builder.HasOne(x => x.Material).WithMany(x => x.BillDetails).HasForeignKey(x => x.IdMaterials);
            builder.HasOne(x => x.Bill).WithMany(x => x.BillDetails).HasForeignKey(x => x.IdBill);
        }
    }
}