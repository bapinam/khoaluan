using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuan.Data.Migrations
{
    public partial class MoneyBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 13, 2, 50, 56, 24, DateTimeKind.Local).AddTicks(4451),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 248, DateTimeKind.Local).AddTicks(3233));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 13, 2, 50, 56, 24, DateTimeKind.Local).AddTicks(4905),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 248, DateTimeKind.Local).AddTicks(3656));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 13, 2, 50, 55, 972, DateTimeKind.Local).AddTicks(5293),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 179, DateTimeKind.Local).AddTicks(8449));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 13, 2, 50, 55, 972, DateTimeKind.Local).AddTicks(4854),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 179, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 13, 2, 50, 55, 998, DateTimeKind.Local).AddTicks(6181),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 225, DateTimeKind.Local).AddTicks(8532));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 13, 2, 50, 55, 998, DateTimeKind.Local).AddTicks(5702),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 225, DateTimeKind.Local).AddTicks(8099));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 13, 2, 50, 56, 18, DateTimeKind.Local).AddTicks(9214),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 240, DateTimeKind.Local).AddTicks(4679));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 13, 2, 50, 56, 18, DateTimeKind.Local).AddTicks(9652),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 240, DateTimeKind.Local).AddTicks(5140));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 13, 2, 50, 55, 963, DateTimeKind.Local).AddTicks(7843),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 174, DateTimeKind.Local).AddTicks(6678));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 13, 2, 50, 55, 960, DateTimeKind.Local).AddTicks(4470),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 173, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalMoney",
                table: "Bills",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "BillDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "5b10bdcd-7439-4a9b-a568-d27c462fc6d7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7fde3a6b-63ed-4080-8a65-79f9bb7ceda7", "AQAAAAEAACcQAAAAEOoMMgYsOXcMUoEdqA/J8gmQYRxKla7w030+4RW8Y4GaDHTa95vTJsNuJ5FZ2JonTw==" });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "PurchaseDate" },
                values: new object[] { new DateTime(2021, 5, 13, 2, 50, 56, 135, DateTimeKind.Local).AddTicks(8362), new DateTime(2021, 5, 13, 2, 50, 56, 135, DateTimeKind.Local).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 13, 2, 50, 56, 128, DateTimeKind.Local).AddTicks(8292), new DateTime(2021, 5, 13, 2, 50, 56, 128, DateTimeKind.Local).AddTicks(6969) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 13, 2, 50, 56, 129, DateTimeKind.Local).AddTicks(688), new DateTime(2021, 5, 13, 2, 50, 56, 129, DateTimeKind.Local).AddTicks(677) });

            migrationBuilder.UpdateData(
                table: "OrderPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 13, 2, 50, 56, 133, DateTimeKind.Local).AddTicks(2730), new DateTime(2021, 5, 13, 2, 50, 56, 133, DateTimeKind.Local).AddTicks(5819) });

            migrationBuilder.UpdateData(
                table: "ProcessPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 13, 2, 50, 56, 139, DateTimeKind.Local).AddTicks(4257), new DateTime(2021, 5, 13, 2, 50, 56, 139, DateTimeKind.Local).AddTicks(5527) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 13, 2, 50, 56, 131, DateTimeKind.Local).AddTicks(6958), new DateTime(2021, 5, 13, 2, 50, 56, 131, DateTimeKind.Local).AddTicks(6219) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalMoney",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "BillDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 248, DateTimeKind.Local).AddTicks(3233),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 13, 2, 50, 56, 24, DateTimeKind.Local).AddTicks(4451));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 248, DateTimeKind.Local).AddTicks(3656),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 13, 2, 50, 56, 24, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 179, DateTimeKind.Local).AddTicks(8449),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 13, 2, 50, 55, 972, DateTimeKind.Local).AddTicks(5293));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 179, DateTimeKind.Local).AddTicks(7910),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 13, 2, 50, 55, 972, DateTimeKind.Local).AddTicks(4854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 225, DateTimeKind.Local).AddTicks(8532),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 13, 2, 50, 55, 998, DateTimeKind.Local).AddTicks(6181));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 225, DateTimeKind.Local).AddTicks(8099),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 13, 2, 50, 55, 998, DateTimeKind.Local).AddTicks(5702));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 240, DateTimeKind.Local).AddTicks(4679),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 13, 2, 50, 56, 18, DateTimeKind.Local).AddTicks(9214));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 240, DateTimeKind.Local).AddTicks(5140),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 13, 2, 50, 56, 18, DateTimeKind.Local).AddTicks(9652));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 174, DateTimeKind.Local).AddTicks(6678),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 13, 2, 50, 55, 963, DateTimeKind.Local).AddTicks(7843));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 173, DateTimeKind.Local).AddTicks(1195),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 13, 2, 50, 55, 960, DateTimeKind.Local).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "f5f0d842-b33a-4698-8690-f005a8895c7a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "55404d1e-c08e-4360-96f8-fc7dc25bd95f", "AQAAAAEAACcQAAAAEAeIrRzMFPdmzsTQfqXlBuHYOJv+S9CgY+anXWBWj3Cr4PiSnUzFH3PQsuO3i+/ZGg==" });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "PurchaseDate" },
                values: new object[] { new DateTime(2021, 5, 10, 13, 32, 36, 296, DateTimeKind.Local).AddTicks(5141), new DateTime(2021, 5, 10, 13, 32, 36, 296, DateTimeKind.Local).AddTicks(4497) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 10, 13, 32, 36, 292, DateTimeKind.Local).AddTicks(3851), new DateTime(2021, 5, 10, 13, 32, 36, 292, DateTimeKind.Local).AddTicks(3121) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 10, 13, 32, 36, 292, DateTimeKind.Local).AddTicks(5092), new DateTime(2021, 5, 10, 13, 32, 36, 292, DateTimeKind.Local).AddTicks(5084) });

            migrationBuilder.UpdateData(
                table: "OrderPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 10, 13, 32, 36, 295, DateTimeKind.Local).AddTicks(2676), new DateTime(2021, 5, 10, 13, 32, 36, 295, DateTimeKind.Local).AddTicks(3501) });

            migrationBuilder.UpdateData(
                table: "ProcessPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 10, 13, 32, 36, 298, DateTimeKind.Local).AddTicks(3857), new DateTime(2021, 5, 10, 13, 32, 36, 298, DateTimeKind.Local).AddTicks(4500) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 10, 13, 32, 36, 293, DateTimeKind.Local).AddTicks(7163), new DateTime(2021, 5, 10, 13, 32, 36, 293, DateTimeKind.Local).AddTicks(6528) });
        }
    }
}
