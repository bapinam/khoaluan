using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuan.Data.Migrations
{
    public partial class StausOrderPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 787, DateTimeKind.Local).AddTicks(3528),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 338, DateTimeKind.Local).AddTicks(2916));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 787, DateTimeKind.Local).AddTicks(3929),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 338, DateTimeKind.Local).AddTicks(3342));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 748, DateTimeKind.Local).AddTicks(701),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 286, DateTimeKind.Local).AddTicks(6955));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 748, DateTimeKind.Local).AddTicks(202),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 286, DateTimeKind.Local).AddTicks(6368));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "OrderPlans",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 762, DateTimeKind.Local).AddTicks(5962),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 302, DateTimeKind.Local).AddTicks(3659));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 762, DateTimeKind.Local).AddTicks(5439),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 302, DateTimeKind.Local).AddTicks(2506));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 779, DateTimeKind.Local).AddTicks(6858),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 328, DateTimeKind.Local).AddTicks(4409));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 779, DateTimeKind.Local).AddTicks(7601),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 328, DateTimeKind.Local).AddTicks(8293));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 741, DateTimeKind.Local).AddTicks(7967),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 277, DateTimeKind.Local).AddTicks(4867));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 738, DateTimeKind.Local).AddTicks(5098),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 275, DateTimeKind.Local).AddTicks(3261));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "778ad087-34d1-43d7-b99a-8a318902315f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "55cdbb43-32b4-4918-ad07-e8516e3a1996", "AQAAAAEAACcQAAAAEO0PObhj8BUGnxG1ZMnNA6eNUIoYewugglKXrqagqGt3nqOMzs6/EQzFn8u+3qMf7w==" });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "PurchaseDate" },
                values: new object[] { new DateTime(2021, 5, 7, 21, 55, 30, 839, DateTimeKind.Local).AddTicks(3926), new DateTime(2021, 5, 7, 21, 55, 30, 839, DateTimeKind.Local).AddTicks(2585) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 7, 21, 55, 30, 835, DateTimeKind.Local).AddTicks(361), new DateTime(2021, 5, 7, 21, 55, 30, 834, DateTimeKind.Local).AddTicks(9693) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 7, 21, 55, 30, 835, DateTimeKind.Local).AddTicks(1554), new DateTime(2021, 5, 7, 21, 55, 30, 835, DateTimeKind.Local).AddTicks(1547) });

            migrationBuilder.UpdateData(
                table: "OrderPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate", "Status" },
                values: new object[] { new DateTime(2021, 5, 7, 21, 55, 30, 837, DateTimeKind.Local).AddTicks(6959), new DateTime(2021, 5, 7, 21, 55, 30, 837, DateTimeKind.Local).AddTicks(7589), 0 });

            migrationBuilder.UpdateData(
                table: "ProcessPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 7, 21, 55, 30, 841, DateTimeKind.Local).AddTicks(6204), new DateTime(2021, 5, 7, 21, 55, 30, 841, DateTimeKind.Local).AddTicks(6896) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 7, 21, 55, 30, 836, DateTimeKind.Local).AddTicks(3026), new DateTime(2021, 5, 7, 21, 55, 30, 836, DateTimeKind.Local).AddTicks(2395) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 338, DateTimeKind.Local).AddTicks(2916),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 787, DateTimeKind.Local).AddTicks(3528));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 338, DateTimeKind.Local).AddTicks(3342),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 787, DateTimeKind.Local).AddTicks(3929));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 286, DateTimeKind.Local).AddTicks(6955),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 748, DateTimeKind.Local).AddTicks(701));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 286, DateTimeKind.Local).AddTicks(6368),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 748, DateTimeKind.Local).AddTicks(202));

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "OrderPlans",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 302, DateTimeKind.Local).AddTicks(3659),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 762, DateTimeKind.Local).AddTicks(5962));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 302, DateTimeKind.Local).AddTicks(2506),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 762, DateTimeKind.Local).AddTicks(5439));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 328, DateTimeKind.Local).AddTicks(4409),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 779, DateTimeKind.Local).AddTicks(6858));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 328, DateTimeKind.Local).AddTicks(8293),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 779, DateTimeKind.Local).AddTicks(7601));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 277, DateTimeKind.Local).AddTicks(4867),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 741, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 2, 15, 46, 5, 275, DateTimeKind.Local).AddTicks(3261),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 738, DateTimeKind.Local).AddTicks(5098));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "423b985b-2fb9-475e-a845-e02864d77565");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "03bc3144-c525-4a1f-9781-b02a930b2fbd", "AQAAAAEAACcQAAAAEB0EijTNTy+LRa4GJKEqaE0XAm1vBE2jY19uec0461PFSXz8rlO0JCkKySL40TIz8Q==" });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "PurchaseDate" },
                values: new object[] { new DateTime(2021, 5, 2, 15, 46, 5, 410, DateTimeKind.Local).AddTicks(3689), new DateTime(2021, 5, 2, 15, 46, 5, 410, DateTimeKind.Local).AddTicks(3068) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 2, 15, 46, 5, 406, DateTimeKind.Local).AddTicks(5350), new DateTime(2021, 5, 2, 15, 46, 5, 406, DateTimeKind.Local).AddTicks(4624) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 2, 15, 46, 5, 406, DateTimeKind.Local).AddTicks(6572), new DateTime(2021, 5, 2, 15, 46, 5, 406, DateTimeKind.Local).AddTicks(6566) });

            migrationBuilder.UpdateData(
                table: "OrderPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate", "Status" },
                values: new object[] { new DateTime(2021, 5, 2, 15, 46, 5, 409, DateTimeKind.Local).AddTicks(2508), new DateTime(2021, 5, 2, 15, 46, 5, 409, DateTimeKind.Local).AddTicks(3149), true });

            migrationBuilder.UpdateData(
                table: "ProcessPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 2, 15, 46, 5, 413, DateTimeKind.Local).AddTicks(3860), new DateTime(2021, 5, 2, 15, 46, 5, 413, DateTimeKind.Local).AddTicks(4883) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 2, 15, 46, 5, 407, DateTimeKind.Local).AddTicks(8613), new DateTime(2021, 5, 2, 15, 46, 5, 407, DateTimeKind.Local).AddTicks(7959) });
        }
    }
}
