using KhoaLuan.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Data.Configurations
{
    public class ProcessingVoucherCF : IEntityTypeConfiguration<ProcessingVoucher>
    {
        public void Configure(EntityTypeBuilder<ProcessingVoucher> builder)
        {
            builder.ToTable("ProcessingVouchers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Code).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Status).HasDefaultValue(false);
            builder.Property(x => x.CreateDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.CompleteDate).HasDefaultValue(DateTime.Now);

            builder.HasIndex(p => p.Code).IsUnique();

            builder.HasOne(x => x.ProcessPlan).WithMany(x => x.ProcessingVouchers).HasForeignKey(x => x.IdPlan);
            builder.HasOne(x => x.Creator).WithMany(x => x.ProcessingVouchers).HasForeignKey(x => x.IdCreator);
        }
    }
}