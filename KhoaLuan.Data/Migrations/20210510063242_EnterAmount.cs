using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuan.Data.Migrations
{
    public partial class EnterAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 248, DateTimeKind.Local).AddTicks(3233),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 803, DateTimeKind.Local).AddTicks(336));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 248, DateTimeKind.Local).AddTicks(3656),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 803, DateTimeKind.Local).AddTicks(932));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 179, DateTimeKind.Local).AddTicks(8449),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 749, DateTimeKind.Local).AddTicks(4399));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 179, DateTimeKind.Local).AddTicks(7910),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 749, DateTimeKind.Local).AddTicks(3318));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 225, DateTimeKind.Local).AddTicks(8532),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 764, DateTimeKind.Local).AddTicks(739));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 225, DateTimeKind.Local).AddTicks(8099),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 763, DateTimeKind.Local).AddTicks(9624));

            migrationBuilder.AddColumn<int>(
                name: "EnterAmount",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 240, DateTimeKind.Local).AddTicks(4679),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 795, DateTimeKind.Local).AddTicks(331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 240, DateTimeKind.Local).AddTicks(5140),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 795, DateTimeKind.Local).AddTicks(1037));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 174, DateTimeKind.Local).AddTicks(6678),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 741, DateTimeKind.Local).AddTicks(9303));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 173, DateTimeKind.Local).AddTicks(1195),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 739, DateTimeKind.Local).AddTicks(9626));

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
                columns: new[] { "Code", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "Admin", "55404d1e-c08e-4360-96f8-fc7dc25bd95f", "AQAAAAEAACcQAAAAEAeIrRzMFPdmzsTQfqXlBuHYOJv+S9CgY+anXWBWj3Cr4PiSnUzFH3PQsuO3i+/ZGg==" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnterAmount",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 803, DateTimeKind.Local).AddTicks(336),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 248, DateTimeKind.Local).AddTicks(3233));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 803, DateTimeKind.Local).AddTicks(932),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 248, DateTimeKind.Local).AddTicks(3656));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 749, DateTimeKind.Local).AddTicks(4399),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 179, DateTimeKind.Local).AddTicks(8449));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 749, DateTimeKind.Local).AddTicks(3318),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 179, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 764, DateTimeKind.Local).AddTicks(739),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 225, DateTimeKind.Local).AddTicks(8532));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 763, DateTimeKind.Local).AddTicks(9624),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 225, DateTimeKind.Local).AddTicks(8099));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 795, DateTimeKind.Local).AddTicks(331),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 240, DateTimeKind.Local).AddTicks(4679));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 795, DateTimeKind.Local).AddTicks(1037),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 240, DateTimeKind.Local).AddTicks(5140));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 741, DateTimeKind.Local).AddTicks(9303),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 174, DateTimeKind.Local).AddTicks(6678));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 739, DateTimeKind.Local).AddTicks(9626),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 10, 13, 32, 36, 173, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "d4a1a49b-af28-4839-8a5e-3f7702479999");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "Code", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "Admin123456789", "1eafb3d9-ab71-49d0-ad47-18ff44e7237e", "AQAAAAEAACcQAAAAEH8ZjtUDdTG2JBnX1hrpIRk4nZ0hN7bFzhf8jmnKTWzDgEpLpRZz4JRm1Dm6/WvWTw==" });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "PurchaseDate" },
                values: new object[] { new DateTime(2021, 5, 8, 16, 29, 29, 878, DateTimeKind.Local).AddTicks(6400), new DateTime(2021, 5, 8, 16, 29, 29, 878, DateTimeKind.Local).AddTicks(5534) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 8, 16, 29, 29, 873, DateTimeKind.Local).AddTicks(3465), new DateTime(2021, 5, 8, 16, 29, 29, 873, DateTimeKind.Local).AddTicks(2530) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 8, 16, 29, 29, 873, DateTimeKind.Local).AddTicks(5067), new DateTime(2021, 5, 8, 16, 29, 29, 873, DateTimeKind.Local).AddTicks(5054) });

            migrationBuilder.UpdateData(
                table: "OrderPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 8, 16, 29, 29, 877, DateTimeKind.Local).AddTicks(1067), new DateTime(2021, 5, 8, 16, 29, 29, 877, DateTimeKind.Local).AddTicks(1937) });

            migrationBuilder.UpdateData(
                table: "ProcessPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 8, 16, 29, 29, 881, DateTimeKind.Local).AddTicks(2046), new DateTime(2021, 5, 8, 16, 29, 29, 881, DateTimeKind.Local).AddTicks(2901) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 8, 16, 29, 29, 875, DateTimeKind.Local).AddTicks(1893), new DateTime(2021, 5, 8, 16, 29, 29, 875, DateTimeKind.Local).AddTicks(974) });
        }
    }
}
