using KhoaLuan.Data.Entities;
using KhoaLuan.Utilities.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Configurations
{
    internal class ProductTypeCF : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("ProductTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Code).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150).UseCollation(SystemConstants.Collate_AI);
            builder.HasIndex(p => new { p.Code, p.Name }).IsUnique();

            builder.HasOne(x => x.ProductTypeGroup).WithMany(x => x.ProductTypes).HasForeignKey(x => x.IdProductTypeGroup);
        }
    }
}