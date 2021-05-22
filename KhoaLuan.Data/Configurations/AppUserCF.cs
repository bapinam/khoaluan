using KhoaLuan.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Configurations
{
    public class AppUserCF : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");
            builder.Property(x => x.Code).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Card).IsRequired().HasMaxLength(20);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.BirthDay).IsRequired();
            builder.Property(x => x.Address).IsRequired().HasMaxLength(250);
            builder.Property(x => x.AccountType).HasDefaultValue(false);
            builder.Property(x => x.PathImage).HasDefaultValue(null);

            builder.HasIndex(p => new { p.Code, p.Card }).IsUnique();
        }
    }
}