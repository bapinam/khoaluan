using KhoaLuan.Data.Entities;
using KhoaLuan.Utilities.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Configurations
{
    public class MaterialsTypeCF : IEntityTypeConfiguration<MaterialsType>
    {
        public void Configure(EntityTypeBuilder<MaterialsType> builder)
        {
            builder.ToTable("MaterialsTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Code).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150).UseCollation(SystemConstants.Collate_AI);
            builder.Property(x => x.GroupType).IsRequired();
        }
    }
}