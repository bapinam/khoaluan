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
    public class ManageCodeCF : IEntityTypeConfiguration<ManageCode>
    {
        public void Configure(EntityTypeBuilder<ManageCode> builder)
        {
            builder.ToTable("ManageCodes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Top).HasDefaultValue(false);
            builder.Property(x => x.Location).HasDefaultValue(0);

            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}