using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuan.Data.Migrations
{
    public partial class UnitRecipes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Recipes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 587, DateTimeKind.Local).AddTicks(4234),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 32, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 587, DateTimeKind.Local).AddTicks(4875),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 32, DateTimeKind.Local).AddTicks(6372));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 546, DateTimeKind.Local).AddTicks(6581),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 16, 992, DateTimeKind.Local).AddTicks(1563));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 546, DateTimeKind.Local).AddTicks(6159),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 16, 992, DateTimeKind.Local).AddTicks(1071));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 565, DateTimeKind.Local).AddTicks(5974),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 10, DateTimeKind.Local).AddTicks(6900));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 565, DateTimeKind.Local).AddTicks(5539),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 10, DateTimeKind.Local).AddTicks(6411));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 580, DateTimeKind.Local).AddTicks(1575),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 25, DateTimeKind.Local).AddTicks(9365));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 580, DateTimeKind.Local).AddTicks(1987),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 25, DateTimeKind.Local).AddTicks(9789));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 541, DateTimeKind.Local).AddTicks(8583),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 16, 987, DateTimeKind.Local).AddTicks(1068));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 540, DateTimeKind.Local).AddTicks(4339),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 16, 985, DateTimeKind.Local).AddTicks(5243));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "d0b68089-2370-4d74-bc70-b51f5ac129ba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "343ecfd9-347d-4874-b037-bc1b9febb09c", "AQAAAAEAACcQAAAAEIpakQ6bNTc9lLaoT1HSZjz6NHsKghVQfFAuZgZG95izUBhmcwL9JaHHVsw9kLZO0A==" });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "PurchaseDate" },
                values: new object[] { new DateTime(2021, 5, 18, 11, 12, 21, 637, DateTimeKind.Local).AddTicks(7636), new DateTime(2021, 5, 18, 11, 12, 21, 637, DateTimeKind.Local).AddTicks(6374) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 18, 11, 12, 21, 632, DateTimeKind.Local).AddTicks(4790), new DateTime(2021, 5, 18, 11, 12, 21, 632, DateTimeKind.Local).AddTicks(4055) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 18, 11, 12, 21, 632, DateTimeKind.Local).AddTicks(6141), new DateTime(2021, 5, 18, 11, 12, 21, 632, DateTimeKind.Local).AddTicks(6133) });

            migrationBuilder.UpdateData(
                table: "OrderPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 18, 11, 12, 21, 635, DateTimeKind.Local).AddTicks(7166), new DateTime(2021, 5, 18, 11, 12, 21, 635, DateTimeKind.Local).AddTicks(7899) });

            migrationBuilder.UpdateData(
                table: "ProcessPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 18, 11, 12, 21, 640, DateTimeKind.Local).AddTicks(8520), new DateTime(2021, 5, 18, 11, 12, 21, 640, DateTimeKind.Local).AddTicks(9682) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 18, 11, 12, 21, 633, DateTimeKind.Local).AddTicks(8971), new DateTime(2021, 5, 18, 11, 12, 21, 633, DateTimeKind.Local).AddTicks(8267) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 32, DateTimeKind.Local).AddTicks(5890),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 587, DateTimeKind.Local).AddTicks(4234));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 32, DateTimeKind.Local).AddTicks(6372),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 587, DateTimeKind.Local).AddTicks(4875));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 10, 54, 16, 992, DateTimeKind.Local).AddTicks(1563),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 546, DateTimeKind.Local).AddTicks(6581));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 10, 54, 16, 992, DateTimeKind.Local).AddTicks(1071),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 546, DateTimeKind.Local).AddTicks(6159));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 10, DateTimeKind.Local).AddTicks(6900),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 565, DateTimeKind.Local).AddTicks(5974));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 10, DateTimeKind.Local).AddTicks(6411),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 565, DateTimeKind.Local).AddTicks(5539));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 25, DateTimeKind.Local).AddTicks(9365),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 580, DateTimeKind.Local).AddTicks(1575));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 25, DateTimeKind.Local).AddTicks(9789),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 580, DateTimeKind.Local).AddTicks(1987));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 10, 54, 16, 987, DateTimeKind.Local).AddTicks(1068),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 541, DateTimeKind.Local).AddTicks(8583));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 10, 54, 16, 985, DateTimeKind.Local).AddTicks(5243),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 540, DateTimeKind.Local).AddTicks(4339));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "13c5ee88-fc6b-4a24-a01d-bb06caf58347");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9306f6dd-8eb0-4b3c-9bf2-237b1404be6d", "AQAAAAEAACcQAAAAEJMIQAbMRV0EPyWgqJNWQpjWJl+MkZGxsH0jH7H1uhcQG1QRBAh5P6ycWxBDZG5ehg==" });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "PurchaseDate" },
                values: new object[] { new DateTime(2021, 5, 18, 10, 54, 17, 83, DateTimeKind.Local).AddTicks(5259), new DateTime(2021, 5, 18, 10, 54, 17, 83, DateTimeKind.Local).AddTicks(4547) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 18, 10, 54, 17, 79, DateTimeKind.Local).AddTicks(1416), new DateTime(2021, 5, 18, 10, 54, 17, 79, DateTimeKind.Local).AddTicks(606) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 18, 10, 54, 17, 79, DateTimeKind.Local).AddTicks(2798), new DateTime(2021, 5, 18, 10, 54, 17, 79, DateTimeKind.Local).AddTicks(2791) });

            migrationBuilder.UpdateData(
                table: "OrderPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 18, 10, 54, 17, 82, DateTimeKind.Local).AddTicks(2357), new DateTime(2021, 5, 18, 10, 54, 17, 82, DateTimeKind.Local).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "ProcessPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 18, 10, 54, 17, 85, DateTimeKind.Local).AddTicks(6062), new DateTime(2021, 5, 18, 10, 54, 17, 85, DateTimeKind.Local).AddTicks(6808) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 18, 10, 54, 17, 80, DateTimeKind.Local).AddTicks(6014), new DateTime(2021, 5, 18, 10, 54, 17, 80, DateTimeKind.Local).AddTicks(5289) });
        }
    }
}
