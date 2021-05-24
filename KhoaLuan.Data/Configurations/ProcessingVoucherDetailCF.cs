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
    public class ProcessingVoucherDetailCF : IEntityTypeConfiguration<ProcessingVoucherDetail>
    {
        public void Configure(EntityTypeBuilder<ProcessingVoucherDetail> builder)
        {
            builder.ToTable("ProcessingVoucherDetails");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Amount).HasDefaultValue(0);

            builder.HasOne(x => x.Recipe).WithMany(x => x.ProcessingVoucherDetails).HasForeignKey(x => x.IdRecipe);
            builder.HasOne(x => x.ProcessingVoucher)
                .WithMany(x => x.ProcessingVoucherDetails).HasForeignKey(x => x.IdVoucher);
        }
    }
}