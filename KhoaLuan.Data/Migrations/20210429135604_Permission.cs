using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuan.Data.Migrations
{
    public partial class Permission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 48, DateTimeKind.Local).AddTicks(4886),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 820, DateTimeKind.Local).AddTicks(8257));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 48, DateTimeKind.Local).AddTicks(5492),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 820, DateTimeKind.Local).AddTicks(8862));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 1, 994, DateTimeKind.Local).AddTicks(1299),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 773, DateTimeKind.Local).AddTicks(5491));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 1, 994, DateTimeKind.Local).AddTicks(516),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 773, DateTimeKind.Local).AddTicks(4871));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 6, DateTimeKind.Local).AddTicks(7386),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 794, DateTimeKind.Local).AddTicks(2957));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 6, DateTimeKind.Local).AddTicks(6574),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 794, DateTimeKind.Local).AddTicks(2233));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 40, DateTimeKind.Local).AddTicks(8699),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 813, DateTimeKind.Local).AddTicks(2257));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 40, DateTimeKind.Local).AddTicks(9370),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 813, DateTimeKind.Local).AddTicks(2901));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 1, 987, DateTimeKind.Local).AddTicks(6062),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 762, DateTimeKind.Local).AddTicks(6336));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 1, 985, DateTimeKind.Local).AddTicks(9130),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 760, DateTimeKind.Local).AddTicks(1634));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<bool>(
                name: "Permission",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "798c4274-b7dd-4a33-a665-b1d44ed669f0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "98cb238a-b6ad-4661-aa07-57a139303242", "AQAAAAEAACcQAAAAEC/0e3A7fW4FojachWlU5Sa5mznezyK5jmKXeQvlLJ8r6hK2rSN95kqUcWqcMukprg==" });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "PurchaseDate" },
                values: new object[] { new DateTime(2021, 4, 29, 20, 56, 2, 105, DateTimeKind.Local).AddTicks(6459), new DateTime(2021, 4, 29, 20, 56, 2, 105, DateTimeKind.Local).AddTicks(5129) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 4, 29, 20, 56, 2, 101, DateTimeKind.Local).AddTicks(6274), new DateTime(2021, 4, 29, 20, 56, 2, 101, DateTimeKind.Local).AddTicks(4885) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 4, 29, 20, 56, 2, 101, DateTimeKind.Local).AddTicks(7606), new DateTime(2021, 4, 29, 20, 56, 2, 101, DateTimeKind.Local).AddTicks(7598) });

            migrationBuilder.UpdateData(
                table: "OrderPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 4, 29, 20, 56, 2, 104, DateTimeKind.Local).AddTicks(3726), new DateTime(2021, 4, 29, 20, 56, 2, 104, DateTimeKind.Local).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "ProcessPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 4, 29, 20, 56, 2, 108, DateTimeKind.Local).AddTicks(8646), new DateTime(2021, 4, 29, 20, 56, 2, 108, DateTimeKind.Local).AddTicks(9612) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 4, 29, 20, 56, 2, 102, DateTimeKind.Local).AddTicks(9584), new DateTime(2021, 4, 29, 20, 56, 2, 102, DateTimeKind.Local).AddTicks(8926) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Permission",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 820, DateTimeKind.Local).AddTicks(8257),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 48, DateTimeKind.Local).AddTicks(4886));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 820, DateTimeKind.Local).AddTicks(8862),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 48, DateTimeKind.Local).AddTicks(5492));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 773, DateTimeKind.Local).AddTicks(5491),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 1, 994, DateTimeKind.Local).AddTicks(1299));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 773, DateTimeKind.Local).AddTicks(4871),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 1, 994, DateTimeKind.Local).AddTicks(516));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 794, DateTimeKind.Local).AddTicks(2957),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 6, DateTimeKind.Local).AddTicks(7386));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 794, DateTimeKind.Local).AddTicks(2233),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 6, DateTimeKind.Local).AddTicks(6574));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 813, DateTimeKind.Local).AddTicks(2257),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 40, DateTimeKind.Local).AddTicks(8699));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 813, DateTimeKind.Local).AddTicks(2901),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 40, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 762, DateTimeKind.Local).AddTicks(6336),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 1, 987, DateTimeKind.Local).AddTicks(6062));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 44, 41, 760, DateTimeKind.Local).AddTicks(1634),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 1, 985, DateTimeKind.Local).AddTicks(9130));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "5baf6fed-bec6-4ad8-81cf-bc9fbf327c1c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a940d98a-7939-48bf-8add-e6ed888f0fb9", "AQAAAAEAACcQAAAAENbH02Ka3aOPSIlD1ciZulEAHRgx/L29M7zJEHgWQFTKXU+q62Okvdyi6cj5jAYZcA==" });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "PurchaseDate" },
                values: new object[] { new DateTime(2021, 4, 27, 21, 44, 41, 918, DateTimeKind.Local).AddTicks(8230), new DateTime(2021, 4, 27, 21, 44, 41, 918, DateTimeKind.Local).AddTicks(5603) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 4, 27, 21, 44, 41, 906, DateTimeKind.Local).AddTicks(7816), new DateTime(2021, 4, 27, 21, 44, 41, 906, DateTimeKind.Local).AddTicks(6577) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 4, 27, 21, 44, 41, 907, DateTimeKind.Local).AddTicks(489), new DateTime(2021, 4, 27, 21, 44, 41, 907, DateTimeKind.Local).AddTicks(463) });

            migrationBuilder.UpdateData(
                table: "OrderPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 4, 27, 21, 44, 41, 915, DateTimeKind.Local).AddTicks(1403), new DateTime(2021, 4, 27, 21, 44, 41, 915, DateTimeKind.Local).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "ProcessPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 4, 27, 21, 44, 41, 922, DateTimeKind.Local).AddTicks(5965), new DateTime(2021, 4, 27, 21, 44, 41, 922, DateTimeKind.Local).AddTicks(7549) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 4, 27, 21, 44, 41, 909, DateTimeKind.Local).AddTicks(6264), new DateTime(2021, 4, 27, 21, 44, 41, 909, DateTimeKind.Local).AddTicks(3685) });
        }
    }
}
