using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuan.Data.Migrations
{
    public partial class UnitRecipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 600, DateTimeKind.Local).AddTicks(1561));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 32, DateTimeKind.Local).AddTicks(6372),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 600, DateTimeKind.Local).AddTicks(1991));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 10, 54, 16, 992, DateTimeKind.Local).AddTicks(1563),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 547, DateTimeKind.Local).AddTicks(4505));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 10, 54, 16, 992, DateTimeKind.Local).AddTicks(1071),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 547, DateTimeKind.Local).AddTicks(3583));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 10, DateTimeKind.Local).AddTicks(6900),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 574, DateTimeKind.Local).AddTicks(3119));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 10, DateTimeKind.Local).AddTicks(6411),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 574, DateTimeKind.Local).AddTicks(2154));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 25, DateTimeKind.Local).AddTicks(9365),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 593, DateTimeKind.Local).AddTicks(2236));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 25, DateTimeKind.Local).AddTicks(9789),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 593, DateTimeKind.Local).AddTicks(2922));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 10, 54, 16, 987, DateTimeKind.Local).AddTicks(1068),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 539, DateTimeKind.Local).AddTicks(7773));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 10, 54, 16, 985, DateTimeKind.Local).AddTicks(5243),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 538, DateTimeKind.Local).AddTicks(2191));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Recipes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 600, DateTimeKind.Local).AddTicks(1561),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 32, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 600, DateTimeKind.Local).AddTicks(1991),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 32, DateTimeKind.Local).AddTicks(6372));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 547, DateTimeKind.Local).AddTicks(4505),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 16, 992, DateTimeKind.Local).AddTicks(1563));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 547, DateTimeKind.Local).AddTicks(3583),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 16, 992, DateTimeKind.Local).AddTicks(1071));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 574, DateTimeKind.Local).AddTicks(3119),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 10, DateTimeKind.Local).AddTicks(6900));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 574, DateTimeKind.Local).AddTicks(2154),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 10, DateTimeKind.Local).AddTicks(6411));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 593, DateTimeKind.Local).AddTicks(2236),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 25, DateTimeKind.Local).AddTicks(9365));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 593, DateTimeKind.Local).AddTicks(2922),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 17, 25, DateTimeKind.Local).AddTicks(9789));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 539, DateTimeKind.Local).AddTicks(7773),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 16, 987, DateTimeKind.Local).AddTicks(1068));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 15, 12, 48, 56, 538, DateTimeKind.Local).AddTicks(2191),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 10, 54, 16, 985, DateTimeKind.Local).AddTicks(5243));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "981a79fa-eab7-415c-883a-1ee9a229791f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2f087fa2-7a04-4cd4-b7e5-64991b2dc2b1", "AQAAAAEAACcQAAAAEARJQSfA0LV8bLm31qPnvTjCaS/HSrfMvHYqmHkmycNCJqdECId7CjEto+CGtnb88A==" });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "PurchaseDate" },
                values: new object[] { new DateTime(2021, 5, 15, 12, 48, 56, 654, DateTimeKind.Local).AddTicks(1660), new DateTime(2021, 5, 15, 12, 48, 56, 654, DateTimeKind.Local).AddTicks(928) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 15, 12, 48, 56, 649, DateTimeKind.Local).AddTicks(8003), new DateTime(2021, 5, 15, 12, 48, 56, 649, DateTimeKind.Local).AddTicks(7177) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 15, 12, 48, 56, 649, DateTimeKind.Local).AddTicks(9376), new DateTime(2021, 5, 15, 12, 48, 56, 649, DateTimeKind.Local).AddTicks(9369) });

            migrationBuilder.UpdateData(
                table: "OrderPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 15, 12, 48, 56, 652, DateTimeKind.Local).AddTicks(7891), new DateTime(2021, 5, 15, 12, 48, 56, 652, DateTimeKind.Local).AddTicks(8625) });

            migrationBuilder.UpdateData(
                table: "ProcessPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 15, 12, 48, 56, 656, DateTimeKind.Local).AddTicks(4749), new DateTime(2021, 5, 15, 12, 48, 56, 656, DateTimeKind.Local).AddTicks(5633) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 15, 12, 48, 56, 651, DateTimeKind.Local).AddTicks(2346), new DateTime(2021, 5, 15, 12, 48, 56, 651, DateTimeKind.Local).AddTicks(1607) });
        }
    }
}
