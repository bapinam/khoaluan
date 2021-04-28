using KhoaLuan.Data.Entities;
using KhoaLuan.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Configurations
{
    public class PackCF : IEntityTypeConfiguration<Pack>
    {
        public void Configure(EntityTypeBuilder<Pack> builder)
        {
            builder.ToTable("Packs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.PackType).IsRequired().HasDefaultValue(PackType.Materials);
            builder.Property(x => x.Default).HasDefaultValue(false);

            builder.Property(x => x.IdMaterials).HasDefaultValue(null);
            builder.Property(x => x.IdProduct).HasDefaultValue(null);
            builder.HasOne(x => x.Material).WithMany(x => x.Packs).HasForeignKey(x => x.IdMaterials);
            builder.HasOne(x => x.Product).WithMany(x => x.Packs).HasForeignKey(x => x.IdProduct);
        }
    }
}