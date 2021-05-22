using KhoaLuan.Data.Entities;
using KhoaLuan.Utilities.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Data.Configurations
{
    public class ProductTypeGroupCF : IEntityTypeConfiguration<ProductTypeGroup>
    {
        public void Configure(EntityTypeBuilder<ProductTypeGroup> builder)
        {
            builder.ToTable("ProductTypeGroups");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Code).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150).UseCollation(SystemConstants.Collate_AI);

            builder.HasIndex(p => new { p.Code, p.Name }).IsUnique();
        }
    }
}