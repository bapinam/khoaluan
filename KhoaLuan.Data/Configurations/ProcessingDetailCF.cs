using KhoaLuan.Data.Entities;
using KhoaLuan.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Configurations
{
    public class ProcessingDetailCF : IEntityTypeConfiguration<ProcessingDetail>
    {
        public void Configure(EntityTypeBuilder<ProcessingDetail> builder)
        {
            builder.ToTable("ProcessingDetails");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Unit).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Amount).HasDefaultValue(0);
            builder.Property(x => x.EnterAmount).HasDefaultValue(0);
            builder.Property(x => x.Status).HasDefaultValue(false);
            builder.Property(x => x.Note).HasMaxLength(250);

            builder.HasOne(x => x.Recipe).WithMany(x => x.ProcessingDetails).HasForeignKey(x => x.IdRecipe);
            builder.HasOne(x => x.ProcessPlan).WithMany(x => x.ProcessingDetails).HasForeignKey(x => x.IdProcessPlan);
        }
    }
}