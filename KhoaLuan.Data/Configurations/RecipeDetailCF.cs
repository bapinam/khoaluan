using KhoaLuan.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Configurations
{
    public class RecipeDetailCF : IEntityTypeConfiguration<RecipeDetail>
    {
        public void Configure(EntityTypeBuilder<RecipeDetail> builder)
        {
            builder.ToTable("RecipeDetails");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Unit).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Amount).IsRequired().HasDefaultValue(0);

            builder.HasOne(x => x.Recipe).WithMany(x => x.RecipeDetails).HasForeignKey(x => x.IdRecipe);
            builder.HasOne(x => x.Material).WithMany(x => x.RecipeDetails).HasForeignKey(x => x.IdMaterials);
        }
    }
}