using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuan.Data.Migrations
{
    public partial class ChangeProcess3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingVoucher_AspNetUsers_CreatorId",
                table: "ProcessingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingVoucher_ProcessPlans_ProcessPlanId",
                table: "ProcessingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingVoucherDetail_ProcessingVoucher_ProcessingVoucherId",
                table: "ProcessingVoucherDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingVoucherDetail_Recipes_RecipeId",
                table: "ProcessingVoucherDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessingVoucherDetail",
                table: "ProcessingVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_ProcessingVoucherDetail_ProcessingVoucherId",
                table: "ProcessingVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_ProcessingVoucherDetail_RecipeId",
                table: "ProcessingVoucherDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessingVoucher",
                table: "ProcessingVoucher");

            migrationBuilder.DropIndex(
                name: "IX_ProcessingVoucher_CreatorId",
                table: "ProcessingVoucher");

            migrationBuilder.DropIndex(
                name: "IX_ProcessingVoucher_ProcessPlanId",
                table: "ProcessingVoucher");

            migrationBuilder.DropColumn(
                name: "ProcessingVoucherId",
                table: "ProcessingVoucherDetail");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "ProcessingVoucherDetail");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "ProcessingVoucher");

            migrationBuilder.DropColumn(
                name: "ProcessPlanId",
                table: "ProcessingVoucher");

            migrationBuilder.RenameTable(
                name: "ProcessingVoucherDetail",
                newName: "ProcessingVoucherDetails");

            migrationBuilder.RenameTable(
                name: "ProcessingVoucher",
                newName: "ProcessingVouchers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 740, DateTimeKind.Local).AddTicks(8394),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 932, DateTimeKind.Local).AddTicks(1587));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 740, DateTimeKind.Local).AddTicks(8872),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 932, DateTimeKind.Local).AddTicks(2368));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 699, DateTimeKind.Local).AddTicks(9146),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 875, DateTimeKind.Local).AddTicks(5808));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 699, DateTimeKind.Local).AddTicks(8709),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 875, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 714, DateTimeKind.Local).AddTicks(8581),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 898, DateTimeKind.Local).AddTicks(507));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 714, DateTimeKind.Local).AddTicks(8128),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 897, DateTimeKind.Local).AddTicks(9821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 748, DateTimeKind.Local).AddTicks(7759),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 943, DateTimeKind.Local).AddTicks(110));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 731, DateTimeKind.Local).AddTicks(9906),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 921, DateTimeKind.Local).AddTicks(7789));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 732, DateTimeKind.Local).AddTicks(352),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 921, DateTimeKind.Local).AddTicks(8242));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 694, DateTimeKind.Local).AddTicks(261),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 867, DateTimeKind.Local).AddTicks(5357));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 692, DateTimeKind.Local).AddTicks(4614),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 866, DateTimeKind.Local).AddTicks(498));

            migrationBuilder.AlterColumn<long>(
                name: "IdVoucher",
                table: "ProcessingVoucherDetails",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "ProcessingVoucherDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "ProcessingVouchers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProcessingVouchers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 751, DateTimeKind.Local).AddTicks(8336),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ProcessingVouchers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessingVoucherDetails",
                table: "ProcessingVoucherDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessingVouchers",
                table: "ProcessingVouchers",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "53c62ea9-b572-4fc5-beb8-5affc2fd638f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1554ae55-dc7c-4dfc-8c37-5fc0a61fd0f7", "AQAAAAEAACcQAAAAEJWaRHq7MR8RfCq+7ogziZa9pYVCfpOswSg1oSng09XUzpWXvWfQM7SwdHBTXSyrxA==" });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 24, 5, 59, 59, 797, DateTimeKind.Local).AddTicks(277), new DateTime(2021, 5, 24, 5, 59, 59, 796, DateTimeKind.Local).AddTicks(9535) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 24, 5, 59, 59, 797, DateTimeKind.Local).AddTicks(1804), new DateTime(2021, 5, 24, 5, 59, 59, 797, DateTimeKind.Local).AddTicks(1797) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 24, 5, 59, 59, 798, DateTimeKind.Local).AddTicks(4850), new DateTime(2021, 5, 24, 5, 59, 59, 798, DateTimeKind.Local).AddTicks(4129) });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingVoucherDetails_IdRecipe",
                table: "ProcessingVoucherDetails",
                column: "IdRecipe");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingVoucherDetails_IdVoucher",
                table: "ProcessingVoucherDetails",
                column: "IdVoucher");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingVouchers_Code",
                table: "ProcessingVouchers",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingVouchers_IdCreator",
                table: "ProcessingVouchers",
                column: "IdCreator");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingVouchers_IdPlan",
                table: "ProcessingVouchers",
                column: "IdPlan");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingVoucherDetails_ProcessingVouchers_IdVoucher",
                table: "ProcessingVoucherDetails",
                column: "IdVoucher",
                principalTable: "ProcessingVouchers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingVoucherDetails_Recipes_IdRecipe",
                table: "ProcessingVoucherDetails",
                column: "IdRecipe",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingVouchers_AspNetUsers_IdCreator",
                table: "ProcessingVouchers",
                column: "IdCreator",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingVouchers_ProcessPlans_IdPlan",
                table: "ProcessingVouchers",
                column: "IdPlan",
                principalTable: "ProcessPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingVoucherDetails_ProcessingVouchers_IdVoucher",
                table: "ProcessingVoucherDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingVoucherDetails_Recipes_IdRecipe",
                table: "ProcessingVoucherDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingVouchers_AspNetUsers_IdCreator",
                table: "ProcessingVouchers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingVouchers_ProcessPlans_IdPlan",
                table: "ProcessingVouchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessingVouchers",
                table: "ProcessingVouchers");

            migrationBuilder.DropIndex(
                name: "IX_ProcessingVouchers_Code",
                table: "ProcessingVouchers");

            migrationBuilder.DropIndex(
                name: "IX_ProcessingVouchers_IdCreator",
                table: "ProcessingVouchers");

            migrationBuilder.DropIndex(
                name: "IX_ProcessingVouchers_IdPlan",
                table: "ProcessingVouchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessingVoucherDetails",
                table: "ProcessingVoucherDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProcessingVoucherDetails_IdRecipe",
                table: "ProcessingVoucherDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProcessingVoucherDetails_IdVoucher",
                table: "ProcessingVoucherDetails");

            migrationBuilder.RenameTable(
                name: "ProcessingVouchers",
                newName: "ProcessingVoucher");

            migrationBuilder.RenameTable(
                name: "ProcessingVoucherDetails",
                newName: "ProcessingVoucherDetail");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 932, DateTimeKind.Local).AddTicks(1587),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 740, DateTimeKind.Local).AddTicks(8394));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 932, DateTimeKind.Local).AddTicks(2368),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 740, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 875, DateTimeKind.Local).AddTicks(5808),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 699, DateTimeKind.Local).AddTicks(9146));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 875, DateTimeKind.Local).AddTicks(5180),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 699, DateTimeKind.Local).AddTicks(8709));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 898, DateTimeKind.Local).AddTicks(507),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 714, DateTimeKind.Local).AddTicks(8581));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 897, DateTimeKind.Local).AddTicks(9821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 714, DateTimeKind.Local).AddTicks(8128));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 943, DateTimeKind.Local).AddTicks(110),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 748, DateTimeKind.Local).AddTicks(7759));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 921, DateTimeKind.Local).AddTicks(7789),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 731, DateTimeKind.Local).AddTicks(9906));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 921, DateTimeKind.Local).AddTicks(8242),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 732, DateTimeKind.Local).AddTicks(352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 867, DateTimeKind.Local).AddTicks(5357),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 694, DateTimeKind.Local).AddTicks(261));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 866, DateTimeKind.Local).AddTicks(498),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 692, DateTimeKind.Local).AddTicks(4614));

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "ProcessingVoucher",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProcessingVoucher",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 751, DateTimeKind.Local).AddTicks(8336));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ProcessingVoucher",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "ProcessingVoucher",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProcessPlanId",
                table: "ProcessingVoucher",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdVoucher",
                table: "ProcessingVoucherDetail",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "ProcessingVoucherDetail",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ProcessingVoucherId",
                table: "ProcessingVoucherDetail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "ProcessingVoucherDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessingVoucher",
                table: "ProcessingVoucher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessingVoucherDetail",
                table: "ProcessingVoucherDetail",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "83fd3a2b-64e1-4fc7-a4c9-200451cdfc41");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a79bdafc-6559-40df-a319-e4d623e9dd3b", "AQAAAAEAACcQAAAAEGku5Y7GxbVbltk7/BySNKQyG6sEBYvDXqqCEY42ooVtskaKSJLVnMhswbwkZljBNw==" });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 24, 5, 48, 14, 999, DateTimeKind.Local).AddTicks(8960), new DateTime(2021, 5, 24, 5, 48, 14, 999, DateTimeKind.Local).AddTicks(8219) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 24, 5, 48, 15, 0, DateTimeKind.Local).AddTicks(534), new DateTime(2021, 5, 24, 5, 48, 15, 0, DateTimeKind.Local).AddTicks(522) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 24, 5, 48, 15, 1, DateTimeKind.Local).AddTicks(8793), new DateTime(2021, 5, 24, 5, 48, 15, 1, DateTimeKind.Local).AddTicks(7208) });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingVoucher_CreatorId",
                table: "ProcessingVoucher",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingVoucher_ProcessPlanId",
                table: "ProcessingVoucher",
                column: "ProcessPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingVoucherDetail_ProcessingVoucherId",
                table: "ProcessingVoucherDetail",
                column: "ProcessingVoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingVoucherDetail_RecipeId",
                table: "ProcessingVoucherDetail",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingVoucher_AspNetUsers_CreatorId",
                table: "ProcessingVoucher",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingVoucher_ProcessPlans_ProcessPlanId",
                table: "ProcessingVoucher",
                column: "ProcessPlanId",
                principalTable: "ProcessPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingVoucherDetail_ProcessingVoucher_ProcessingVoucherId",
                table: "ProcessingVoucherDetail",
                column: "ProcessingVoucherId",
                principalTable: "ProcessingVoucher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingVoucherDetail_Recipes_RecipeId",
                table: "ProcessingVoucherDetail",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
