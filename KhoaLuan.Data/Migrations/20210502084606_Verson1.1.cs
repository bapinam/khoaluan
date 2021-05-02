using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuan.Data.Migrations
{
    public partial class Verson11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Card = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AccountType = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobStatus = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManageCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Top = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TypeCode = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManageCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AI"),
                    GroupType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialsTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypeGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AI")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypeGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Tax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AI"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OrderPlans",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<bool>(type: "bit", nullable: false),
                    Censorship = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 302, DateTimeKind.Local).AddTicks(2506)),
                    ExpectedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 302, DateTimeKind.Local).AddTicks(3659)),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IdCreator = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdResponsible = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPlans_AspNetUsers_IdCreator",
                        column: x => x.IdCreator,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderPlans_AspNetUsers_IdResponsible",
                        column: x => x.IdResponsible,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProcessPlans",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 286, DateTimeKind.Local).AddTicks(6368)),
                    ExpectedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 286, DateTimeKind.Local).AddTicks(6955)),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Censorship = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IdCreator = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdResponsible = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessPlans_AspNetUsers_IdCreator",
                        column: x => x.IdCreator,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProcessPlans_AspNetUsers_IdResponsible",
                        column: x => x.IdResponsible,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AI"),
                    Amount = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    Min = table.Column<long>(type: "bigint", nullable: true),
                    Max = table.Column<long>(type: "bigint", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReminderStartDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 328, DateTimeKind.Local).AddTicks(4409)),
                    ReminderEndDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 328, DateTimeKind.Local).AddTicks(8293)),
                    Reminder = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IdMaterialsType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_MaterialsTypes_IdMaterialsType",
                        column: x => x.IdMaterialsType,
                        principalTable: "MaterialsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AI"),
                    IdProductTypeGroup = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTypes_ProductTypeGroups_IdProductTypeGroup",
                        column: x => x.IdProductTypeGroup,
                        principalTable: "ProductTypeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeBill = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StorageCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 277, DateTimeKind.Local).AddTicks(4867)),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 275, DateTimeKind.Local).AddTicks(3261)),
                    Tax = table.Column<int>(type: "int", nullable: true),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSupplier = table.Column<int>(type: "int", nullable: false),
                    IdPlan = table.Column<long>(type: "bigint", nullable: false),
                    IdCreator = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_AspNetUsers_IdCreator",
                        column: x => x.IdCreator,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Bills_OrderPlans_IdPlan",
                        column: x => x.IdPlan,
                        principalTable: "OrderPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Bills_Suppliers_IdSupplier",
                        column: x => x.IdSupplier,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IdSupplier = table.Column<int>(type: "int", nullable: true),
                    IdOrderPlan = table.Column<long>(type: "bigint", nullable: false),
                    IdMaterials = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Materials_IdMaterials",
                        column: x => x.IdMaterials,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderPlans_IdOrderPlan",
                        column: x => x.IdOrderPlan,
                        principalTable: "OrderPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Suppliers_IdSupplier",
                        column: x => x.IdSupplier,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AI"),
                    Amount = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    Min = table.Column<long>(type: "bigint", nullable: true),
                    Max = table.Column<long>(type: "bigint", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReminderStartDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 338, DateTimeKind.Local).AddTicks(2916)),
                    ReminderEndDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 338, DateTimeKind.Local).AddTicks(3342)),
                    Reminder = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IdProductType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_IdProductType",
                        column: x => x.IdProductType,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BillDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    IdMaterials = table.Column<int>(type: "int", nullable: false),
                    IdBill = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillDetails_Bills_IdBill",
                        column: x => x.IdBill,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BillDetails_Materials_IdMaterials",
                        column: x => x.IdMaterials,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Packs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<long>(type: "bigint", nullable: false),
                    Default = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PackType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IdProduct = table.Column<int>(type: "int", nullable: true),
                    IdMaterials = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packs_Materials_IdMaterials",
                        column: x => x.IdMaterials,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Packs_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prioritize = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IdProduct = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProcessingDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IdRecipe = table.Column<int>(type: "int", nullable: false),
                    IdProcessPlan = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessingDetails_ProcessPlans_IdProcessPlan",
                        column: x => x.IdProcessPlan,
                        principalTable: "ProcessPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProcessingDetails_Recipes_IdRecipe",
                        column: x => x.IdRecipe,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RecipeDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdRecipe = table.Column<int>(type: "int", nullable: false),
                    IdMaterials = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeDetails_Materials_IdMaterials",
                        column: x => x.IdMaterials,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RecipeDetails_Recipes_IdRecipe",
                        column: x => x.IdRecipe,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"), "423b985b-2fb9-475e-a845-e02864d77565", "Vai trò Administrator", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountType", "Address", "BirthDay", "Card", "Code", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "JobStatus", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PathImage", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"), 0, true, "Cần Thơ", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "Admin123456789", "03bc3144-c525-4a1f-9781-b02a930b2fbd", "khoaluan@gmail.com", true, "Nam", true, 1, "Lương Nhựt", false, null, "khoaluan@gmail.com", "admin", "AQAAAAEAACcQAAAAEB0EijTNTy+LRa4GJKEqaE0XAm1vBE2jY19uec0461PFSXz8rlO0JCkKySL40TIz8Q==", null, null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "MaterialsTypes",
                columns: new[] { "Id", "Code", "GroupType", "Name" },
                values: new object[,]
                {
                    { 1, "LoaiNVL1", 0, "Bột" },
                    { 2, "LoaiNVL2", 0, "Trái Cây" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypeGroups",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 1, "NhomLSP1", "Thực Phẩm" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "Code", "Email", "Name", "Phone", "Tax" },
                values: new object[] { 1, "Cần Thơ", "NCC1", "nhacungcap@gmail.com", "Công Ty ABO", "0869696969", "011" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"), new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0") });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Amount", "Code", "Description", "IdMaterialsType", "Image", "Max", "Min", "Name", "ReminderEndDate", "ReminderStartDate" },
                values: new object[,]
                {
                    { 1, 10L, "NVL1", "Bột gạo dùng để làm bánh", 1, null, 100L, 1L, "Bột gạo", new DateTime(2021, 5, 2, 15, 46, 5, 406, DateTimeKind.Local).AddTicks(5350), new DateTime(2021, 5, 2, 15, 46, 5, 406, DateTimeKind.Local).AddTicks(4624) },
                    { 2, 10L, "NVL2", "Bột gạo dùng để làm bánh", 2, null, 100L, 10L, "Cam", new DateTime(2021, 5, 2, 15, 46, 5, 406, DateTimeKind.Local).AddTicks(6572), new DateTime(2021, 5, 2, 15, 46, 5, 406, DateTimeKind.Local).AddTicks(6566) }
                });

            migrationBuilder.InsertData(
                table: "OrderPlans",
                columns: new[] { "Id", "Censorship", "Code", "CreatedDate", "ExpectedDate", "IdCreator", "IdResponsible", "Name", "Note", "Order", "Status" },
                values: new object[] { 1L, true, "KHDH1", new DateTime(2021, 5, 2, 15, 46, 5, 409, DateTimeKind.Local).AddTicks(2508), new DateTime(2021, 5, 2, 15, 46, 5, 409, DateTimeKind.Local).AddTicks(3149), new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"), new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"), "Đặt hàng bột gạo và cam", null, false, true });

            migrationBuilder.InsertData(
                table: "ProcessPlans",
                columns: new[] { "Id", "Code", "CreatedDate", "ExpectedDate", "IdCreator", "IdResponsible", "Name", "Note" },
                values: new object[] { 1L, "KHCB1", new DateTime(2021, 5, 2, 15, 46, 5, 413, DateTimeKind.Local).AddTicks(3860), new DateTime(2021, 5, 2, 15, 46, 5, 413, DateTimeKind.Local).AddTicks(4883), new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"), new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"), "Chế Biến bánh cam", null });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Code", "IdProductTypeGroup", "Name" },
                values: new object[] { 1, "LSP1", 1, "Bánh" });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "AmountPaid", "CodeBill", "CreatedDate", "IdCreator", "IdPlan", "IdSupplier", "Images", "PaymentStatus", "PurchaseDate", "StorageCode", "Tax" },
                values: new object[] { 1L, 50000m, "01", new DateTime(2021, 5, 2, 15, 46, 5, 410, DateTimeKind.Local).AddTicks(3689), new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"), 1L, 1, null, 1, new DateTime(2021, 5, 2, 15, 46, 5, 410, DateTimeKind.Local).AddTicks(3068), "AP1", null });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Amount", "IdMaterials", "IdOrderPlan", "IdSupplier", "Note", "Price", "Unit" },
                values: new object[,]
                {
                    { 1L, 2, 1, 1L, null, null, null, "kg" },
                    { 2L, 3, 2, 1L, 1, null, null, "Trái" }
                });

            migrationBuilder.InsertData(
                table: "Packs",
                columns: new[] { "Id", "Default", "IdMaterials", "IdProduct", "Name", "Value" },
                values: new object[] { 1L, true, 1, null, "kg", 1L });

            migrationBuilder.InsertData(
                table: "Packs",
                columns: new[] { "Id", "IdMaterials", "IdProduct", "Name", "Value" },
                values: new object[] { 2L, 1, null, "g", 1000L });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "Code", "Description", "IdProductType", "Image", "Max", "Min", "Name", "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { 1, 10L, "SP1", "Bánh làm từ cam vắt", 1, null, 10L, 0L, "Bánh Cam", new DateTime(2021, 5, 2, 15, 46, 5, 407, DateTimeKind.Local).AddTicks(8613), new DateTime(2021, 5, 2, 15, 46, 5, 407, DateTimeKind.Local).AddTicks(7959) });

            migrationBuilder.InsertData(
                table: "BillDetails",
                columns: new[] { "Id", "Amount", "IdBill", "IdMaterials", "Price", "Unit" },
                values: new object[,]
                {
                    { 1L, 2, 1L, 1, 30000m, "kg" },
                    { 2L, 3, 1L, 1, 20000m, "Trái" }
                });

            migrationBuilder.InsertData(
                table: "Packs",
                columns: new[] { "Id", "Default", "IdMaterials", "IdProduct", "Name", "PackType", "Value" },
                values: new object[] { 3L, true, null, 1, "Bánh", 1, 1L });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Code", "IdProduct", "Name", "Note", "Prioritize" },
                values: new object[] { 1, "CTCB1", 1, "Làm bánh Cam", null, true });

            migrationBuilder.InsertData(
                table: "ProcessingDetails",
                columns: new[] { "Id", "Amount", "IdProcessPlan", "IdRecipe", "Note", "Unit" },
                values: new object[] { 1L, 1, 1L, 1, null, "Bánh" });

            migrationBuilder.InsertData(
                table: "RecipeDetails",
                columns: new[] { "Id", "Amount", "IdMaterials", "IdRecipe", "Unit" },
                values: new object[] { 1L, 1, 1, 1, "kg" });

            migrationBuilder.InsertData(
                table: "RecipeDetails",
                columns: new[] { "Id", "Amount", "IdMaterials", "IdRecipe", "Unit" },
                values: new object[] { 2L, 1, 2, 1, "Trái" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_IdBill",
                table: "BillDetails",
                column: "IdBill");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_IdMaterials",
                table: "BillDetails",
                column: "IdMaterials");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_IdCreator",
                table: "Bills",
                column: "IdCreator");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_IdPlan",
                table: "Bills",
                column: "IdPlan");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_IdSupplier",
                table: "Bills",
                column: "IdSupplier");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_IdMaterialsType",
                table: "Materials",
                column: "IdMaterialsType");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_IdMaterials",
                table: "OrderDetails",
                column: "IdMaterials");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_IdOrderPlan",
                table: "OrderDetails",
                column: "IdOrderPlan");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_IdSupplier",
                table: "OrderDetails",
                column: "IdSupplier");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPlans_IdCreator",
                table: "OrderPlans",
                column: "IdCreator");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPlans_IdResponsible",
                table: "OrderPlans",
                column: "IdResponsible");

            migrationBuilder.CreateIndex(
                name: "IX_Packs_IdMaterials",
                table: "Packs",
                column: "IdMaterials");

            migrationBuilder.CreateIndex(
                name: "IX_Packs_IdProduct",
                table: "Packs",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingDetails_IdProcessPlan",
                table: "ProcessingDetails",
                column: "IdProcessPlan");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingDetails_IdRecipe",
                table: "ProcessingDetails",
                column: "IdRecipe");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessPlans_IdCreator",
                table: "ProcessPlans",
                column: "IdCreator");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessPlans_IdResponsible",
                table: "ProcessPlans",
                column: "IdResponsible");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdProductType",
                table: "Products",
                column: "IdProductType");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_IdProductTypeGroup",
                table: "ProductTypes",
                column: "IdProductTypeGroup");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDetails_IdMaterials",
                table: "RecipeDetails",
                column: "IdMaterials");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDetails_IdRecipe",
                table: "RecipeDetails",
                column: "IdRecipe");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_IdProduct",
                table: "Recipes",
                column: "IdProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BillDetails");

            migrationBuilder.DropTable(
                name: "ManageCodes");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Packs");

            migrationBuilder.DropTable(
                name: "ProcessingDetails");

            migrationBuilder.DropTable(
                name: "RecipeDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "ProcessPlans");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "OrderPlans");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "MaterialsTypes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "ProductTypeGroups");
        }
    }
}