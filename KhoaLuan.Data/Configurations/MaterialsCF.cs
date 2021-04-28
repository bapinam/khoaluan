using KhoaLuan.Data.Entities;
using KhoaLuan.Utilities.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Configurations
{
    public class MaterialsCF : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.ToTable("Materials");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Code).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150).UseCollation(SystemConstants.Collate_AI);
            builder.Property(x => x.Image).HasDefaultValue(null);
            builder.Property(x => x.Description).HasDefaultValue(null);
            builder.Property(x => x.Reminder).HasDefaultValue(false);
            builder.Property(x => x.Amount).HasDefaultValue(0);
            builder.Property(x => x.ReminderStartDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ReminderEndDate).HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.MaterialsType).WithMany(x => x.Materials).HasForeignKey(x => x.IdMaterialsType);
        }
    }
}