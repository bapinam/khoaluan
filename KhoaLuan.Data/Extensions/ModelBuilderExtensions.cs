using KhoaLuan.Data.Entities;
using KhoaLuan.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var roleId = new Guid("88A28F0B-99CD-4893-AB70-0189C8C7FEC5");
            var adminId = new Guid("0275D5A7-DA4A-41C3-85ED-15E53CD1B7A0");

            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "Admin",
                Description = "Vai trò Administrator"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                Code = "Admin",
                Card = "0123456789",
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "khoaluan@gmail.com",
                NormalizedEmail = "khoaluan@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456"),
                SecurityStamp = string.Empty,
                LastName = "Lương Nhựt",
                FirstName = "Nam",
                AccountType = true,
                BirthDay = new DateTime(2020, 01, 31),
                Gender = true,
                Address = "Cần Thơ",
                JobStatus = JobStatus.Working
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

            modelBuilder.Entity<MaterialsType>().HasData(
               new MaterialsType() { Id = 1, Code = "LoaiNVL1", Name = "Bột", GroupType = GroupType.NguyenLieu },
               new MaterialsType() { Id = 2, Code = "LoaiNVL2", Name = "Trái Cây", GroupType = GroupType.NguyenLieu }
               );

            modelBuilder.Entity<Material>().HasData(
               new Material()
               {
                   Id = 1,
                   Code = "NVL1",
                   Name = "Bột gạo",
                   Min = 1,
                   Max = 100,
                   Amount = 10,
                   Description = "Bột gạo dùng để làm bánh",
                   ReminderStartDate = DateTime.Now,
                   ReminderEndDate = DateTime.Now,
                   IdMaterialsType = 1
               },
               new Material()
               {
                   Id = 2,
                   Code = "NVL2",
                   Name = "Cam",
                   Min = 10,
                   Max = 100,
                   Amount = 10,
                   Description = "Bột gạo dùng để làm bánh",
                   ReminderStartDate = DateTime.Now,
                   ReminderEndDate = DateTime.Now,
                   IdMaterialsType = 2
               }
               );

            modelBuilder.Entity<ProductTypeGroup>().HasData(
             new ProductTypeGroup()
             {
                 Id = 1,
                 Code = "NhomLSP1",
                 Name = "Thực Phẩm",
             }
             );

            modelBuilder.Entity<ProductType>().HasData(
              new ProductType()
              {
                  Id = 1,
                  Code = "LSP1",
                  Name = "Bánh",
                  IdProductTypeGroup = 1
              }
              );

            modelBuilder.Entity<Product>().HasData(
               new Product()
               {
                   Id = 1,
                   Code = "SP1",
                   Name = "Bánh Cam",
                   Max = 10,
                   Min = 0,
                   Amount = 10,
                   Description = "Bánh làm từ cam vắt",
                   ReminderStartDate = DateTime.Now,
                   ReminderEndDate = DateTime.Now,
                   IdProductType = 1
               }
               );

            modelBuilder.Entity<Pack>().HasData(
              new Pack()
              {
                  Id = 1,
                  Name = "kg",
                  Value = 1,
                  Default = true,
                  PackType = PackType.Materials,
                  IdMaterials = 1
              },
                new Pack()
                {
                    Id = 2,
                    Name = "g",
                    Value = 1000,
                    Default = false,
                    PackType = PackType.Materials,
                    IdMaterials = 1
                },
                new Pack()
                {
                    Id = 3,
                    Name = "Trái",
                    Value = 1,
                    Default = true,
                    PackType = PackType.Materials,
                    IdMaterials = 2
                },
                 new Pack()
                 {
                     Id = 4,
                     Name = "Bánh",
                     Value = 1,
                     Default = true,
                     PackType = PackType.Product,
                     IdProduct = 1
                 }
              );

            modelBuilder.Entity<Supplier>().HasData(
              new Supplier()
              {
                  Id = 1,
                  Code = "NCC1",
                  Tax = "011",
                  Name = "Công Ty ABO",
                  Phone = "0869696969",
                  Email = "nhacungcap@gmail.com",
                  Address = "Cần Thơ"
              }
              );

            modelBuilder.Entity<Recipe>().HasData(
             new Recipe()
             {
                 Id = 1,
                 Code = "CTCB1",
                 Name = "Làm bánh Cam",
                 Prioritize = true,
                 IdProduct = 1
             }
             );

            modelBuilder.Entity<RecipeDetail>().HasData(
             new RecipeDetail()
             {
                 Id = 1,
                 Amount = 1,
                 Unit = "kg",
                 IdRecipe = 1,
                 IdMaterials = 1
             },
              new RecipeDetail()
              {
                  Id = 2,
                  Amount = 1,
                  Unit = "Trái",
                  IdRecipe = 1,
                  IdMaterials = 2
              }
             );
        }
    }
}