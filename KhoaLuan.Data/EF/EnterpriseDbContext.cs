using KhoaLuan.Data.Configurations;
using KhoaLuan.Data.Entities;
using KhoaLuan.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace KhoaLuan.Data.EF
{
    public class EnterpriseDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public EnterpriseDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API
            modelBuilder.ApplyConfiguration(new ProcessingDetailCF());
            modelBuilder.ApplyConfiguration(new RecipeDetailCF());
            modelBuilder.ApplyConfiguration(new OrderDetailCF());
            modelBuilder.ApplyConfiguration(new BillDetailCF());
            modelBuilder.ApplyConfiguration(new RecipeCF());
            modelBuilder.ApplyConfiguration(new PackCF());
            modelBuilder.ApplyConfiguration(new BillCF());
            modelBuilder.ApplyConfiguration(new ProcessPlanCF());
            modelBuilder.ApplyConfiguration(new OrderPlanCF());
            modelBuilder.ApplyConfiguration(new MaterialsTypeCF());
            modelBuilder.ApplyConfiguration(new ProductTypeCF());
            modelBuilder.ApplyConfiguration(new MaterialsCF());
            modelBuilder.ApplyConfiguration(new SupplierCF());
            modelBuilder.ApplyConfiguration(new ProductCF());
            modelBuilder.ApplyConfiguration(new ProductTypeGroupCF());
            modelBuilder.ApplyConfiguration(new ManageCodeCF());
            modelBuilder.ApplyConfiguration(new NotificationCF());

            modelBuilder.ApplyConfiguration(new AppUserCF());
            modelBuilder.ApplyConfiguration(new AppRoleCF());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            //// Create View
            //modelBuilder.Entity<VIngredientRecipe>(eb =>
            //{
            //    eb.HasNoKey();
            //    eb.ToView("View_IngredientRecipe");
            //    eb.Property(v => v.IdReciper).HasColumnName("IdReciper");
            //    eb.Property(v => v.Code).HasColumnName("Code");
            //    eb.Property(v => v.Name).HasColumnName("Name");
            //    eb.Property(v => v.Note).HasColumnName("Note");
            //    eb.Property(v => v.Prioritize).HasColumnName("Prioritize");
            //    eb.Property(v => v.IdMaterials).HasColumnName("IdMaterials");
            //    eb.Property(v => v.NameMaterials).HasColumnName("NameMaterials");
            //    eb.Property(v => v.Amount).HasColumnName("Amount");
            //    eb.Property(v => v.Unit).HasColumnName("Unit");
            //});

            //Data seeding
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<VIngredientRecipe> VIngredientRecipes { get; set; }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ManageCode> ManageCodes { get; set; }
        public DbSet<ProcessingDetail> ProcessingDetails { get; set; }
        public DbSet<RecipeDetail> RecipeDetails { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Pack> Packs { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<ProcessPlan> ProcessPlans { get; set; }
        public DbSet<OrderPlan> OrderPlans { get; set; }
        public DbSet<MaterialsType> MaterialsTypes { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTypeGroup> ProductTypeGroups { get; set; }
    }
}