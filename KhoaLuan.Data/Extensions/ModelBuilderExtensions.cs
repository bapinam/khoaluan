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

            modelBuilder.Entity<OrderPlan>().HasData(
              new OrderPlan()
              {
                  Id = 1,
                  Code = "KHDH1",
                  Name = "Đặt hàng bột gạo và cam",
                  CreatedDate = DateTime.Now,
                  ExpectedDate = DateTime.Now,
                  Status = StatusOrderPlan.Accomplished,
                  Censorship = true,
                  IdResponsible = adminId,
                  IdCreator = adminId
              }
              );

            modelBuilder.Entity<OrderDetail>().HasData(
               new OrderDetail()
               {
                   Id = 1,
                   Amount = 2,
                   Unit = "kg",
                   IdOrderPlan = 1,
                   IdMaterials = 1
               },
               new OrderDetail()
               {
                   Id = 2,
                   Amount = 3,
                   Unit = "Trái",
                   IdOrderPlan = 1,
                   IdMaterials = 2,
                   IdSupplier = 1
               }
               );

            modelBuilder.Entity<Bill>().HasData(
               new Bill()
               {
                   Id = 1,
                   CodeBill = "01",
                   StorageCode = "AP1",
                   PurchaseDate = DateTime.Now,
                   CreatedDate = DateTime.Now,
                   PaymentStatus = PaymentStatus.Paid,
                   AmountPaid = 50000,
                   IdSupplier = 1,
                   IdPlan = 1,
                   IdCreator = adminId
               }
               );

            modelBuilder.Entity<BillDetail>().HasData(
               new BillDetail()
               {
                   Id = 1,
                   Unit = "kg",
                   Amount = 2,
                   Price = 30000,
                   IdMaterials = 1,
                   IdBill = 1
               },
               new BillDetail()
               {
                   Id = 2,
                   Unit = "Trái",
                   Amount = 3,
                   Price = 20000,
                   IdMaterials = 1,
                   IdBill = 1
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

            modelBuilder.Entity<ProcessPlan>().HasData(
              new ProcessPlan()
              {
                  Id = 1,
                  Code = "KHCB1",
                  Name = "Chế Biến bánh cam",
                  CreatedDate = DateTime.Now,
                  ExpectedDate = DateTime.Now,
                  IdResponsible = adminId,
                  IdCreator = adminId
              }
              );

            modelBuilder.Entity<ProcessingDetail>().HasData(
               new ProcessingDetail()
               {
                   Id = 1,
                   Amount = 1,
                   Unit = "Bánh",
                   IdRecipe = 1,
                   IdProcessPlan = 1
               }
               );
        }
    }
}