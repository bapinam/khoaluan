using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuan.Data.Migrations
{
    public partial class Status2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 61, DateTimeKind.Local).AddTicks(5689),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 587, DateTimeKind.Local).AddTicks(4234));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 61, DateTimeKind.Local).AddTicks(6165),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 587, DateTimeKind.Local).AddTicks(4875));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "ProcessPlans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 6, DateTimeKind.Local).AddTicks(7055),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 546, DateTimeKind.Local).AddTicks(6581));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 6, DateTimeKind.Local).AddTicks(6621),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 546, DateTimeKind.Local).AddTicks(6159));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 30, DateTimeKind.Local).AddTicks(8030),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 565, DateTimeKind.Local).AddTicks(5974));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 30, DateTimeKind.Local).AddTicks(7375),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 565, DateTimeKind.Local).AddTicks(5539));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 54, DateTimeKind.Local).AddTicks(9366),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 580, DateTimeKind.Local).AddTicks(1575));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 55, DateTimeKind.Local).AddTicks(581),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 580, DateTimeKind.Local).AddTicks(1987));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 7, 999, DateTimeKind.Local).AddTicks(5548),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 541, DateTimeKind.Local).AddTicks(8583));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 7, 997, DateTimeKind.Local).AddTicks(6825),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 540, DateTimeKind.Local).AddTicks(4339));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "f20aad02-637d-4573-aac0-0479380f4059");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9fb2c020-ac44-4333-8cf1-65b5a11b9933", "AQAAAAEAACcQAAAAEHDZd9WCOvPICiqA9kHrBTPE2E7HtknPWZbXAhU220sHIAu+GripVN1POeLsm5kfYA==" });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "PurchaseDate" },
                values: new object[] { new DateTime(2021, 5, 18, 19, 6, 8, 126, DateTimeKind.Local).AddTicks(2887), new DateTime(2021, 5, 18, 19, 6, 8, 126, DateTimeKind.Local).AddTicks(1326) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 18, 19, 6, 8, 117, DateTimeKind.Local).AddTicks(8632), new DateTime(2021, 5, 18, 19, 6, 8, 117, DateTimeKind.Local).AddTicks(7597) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 18, 19, 6, 8, 118, DateTimeKind.Local).AddTicks(537), new DateTime(2021, 5, 18, 19, 6, 8, 118, DateTimeKind.Local).AddTicks(527) });

            migrationBuilder.UpdateData(
                table: "OrderPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 18, 19, 6, 8, 123, DateTimeKind.Local).AddTicks(9048), new DateTime(2021, 5, 18, 19, 6, 8, 124, DateTimeKind.Local).AddTicks(378) });

            migrationBuilder.UpdateData(
                table: "ProcessPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate", "Status" },
                values: new object[] { new DateTime(2021, 5, 18, 19, 6, 8, 131, DateTimeKind.Local).AddTicks(1993), new DateTime(2021, 5, 18, 19, 6, 8, 131, DateTimeKind.Local).AddTicks(3172), 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 18, 19, 6, 8, 120, DateTimeKind.Local).AddTicks(15), new DateTime(2021, 5, 18, 19, 6, 8, 119, DateTimeKind.Local).AddTicks(9019) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 587, DateTimeKind.Local).AddTicks(4234),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 61, DateTimeKind.Local).AddTicks(5689));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 587, DateTimeKind.Local).AddTicks(4875),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 61, DateTimeKind.Local).AddTicks(6165));

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "ProcessPlans",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 546, DateTimeKind.Local).AddTicks(6581),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 6, DateTimeKind.Local).AddTicks(7055));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 546, DateTimeKind.Local).AddTicks(6159),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 6, DateTimeKind.Local).AddTicks(6621));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 565, DateTimeKind.Local).AddTicks(5974),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 30, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 565, DateTimeKind.Local).AddTicks(5539),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 30, DateTimeKind.Local).AddTicks(7375));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 580, DateTimeKind.Local).AddTicks(1575),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 54, DateTimeKind.Local).AddTicks(9366));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 580, DateTimeKind.Local).AddTicks(1987),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 55, DateTimeKind.Local).AddTicks(581));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 541, DateTimeKind.Local).AddTicks(8583),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 7, 999, DateTimeKind.Local).AddTicks(5548));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 11, 12, 21, 540, DateTimeKind.Local).AddTicks(4339),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 7, 997, DateTimeKind.Local).AddTicks(6825));

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
                columns: new[] { "CreatedDate", "ExpectedDate", "Status" },
                values: new object[] { new DateTime(2021, 5, 18, 11, 12, 21, 640, DateTimeKind.Local).AddTicks(8520), new DateTime(2021, 5, 18, 11, 12, 21, 640, DateTimeKind.Local).AddTicks(9682), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 18, 11, 12, 21, 633, DateTimeKind.Local).AddTicks(8971), new DateTime(2021, 5, 18, 11, 12, 21, 633, DateTimeKind.Local).AddTicks(8267) });
        }
    }
}
