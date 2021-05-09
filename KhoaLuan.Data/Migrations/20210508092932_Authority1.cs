using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuan.Data.Migrations
{
    public partial class Authority1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 803, DateTimeKind.Local).AddTicks(336),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 629, DateTimeKind.Local).AddTicks(8653));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 803, DateTimeKind.Local).AddTicks(932),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 629, DateTimeKind.Local).AddTicks(9348));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 749, DateTimeKind.Local).AddTicks(4399),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 535, DateTimeKind.Local).AddTicks(1148));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 749, DateTimeKind.Local).AddTicks(3318),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 535, DateTimeKind.Local).AddTicks(678));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 764, DateTimeKind.Local).AddTicks(739),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 554, DateTimeKind.Local).AddTicks(1172));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 763, DateTimeKind.Local).AddTicks(9624),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 554, DateTimeKind.Local).AddTicks(314));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 795, DateTimeKind.Local).AddTicks(331),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 614, DateTimeKind.Local).AddTicks(8488));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 795, DateTimeKind.Local).AddTicks(1037),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 614, DateTimeKind.Local).AddTicks(9190));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 741, DateTimeKind.Local).AddTicks(9303),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 525, DateTimeKind.Local).AddTicks(2881));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 739, DateTimeKind.Local).AddTicks(9626),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 523, DateTimeKind.Local).AddTicks(2668));

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1eafb3d9-ab71-49d0-ad47-18ff44e7237e", "AQAAAAEAACcQAAAAEH8ZjtUDdTG2JBnX1hrpIRk4nZ0hN7bFzhf8jmnKTWzDgEpLpRZz4JRm1Dm6/WvWTw==" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 629, DateTimeKind.Local).AddTicks(8653),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 803, DateTimeKind.Local).AddTicks(336));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 629, DateTimeKind.Local).AddTicks(9348),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 803, DateTimeKind.Local).AddTicks(932));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 535, DateTimeKind.Local).AddTicks(1148),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 749, DateTimeKind.Local).AddTicks(4399));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 535, DateTimeKind.Local).AddTicks(678),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 749, DateTimeKind.Local).AddTicks(3318));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 554, DateTimeKind.Local).AddTicks(1172),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 764, DateTimeKind.Local).AddTicks(739));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 554, DateTimeKind.Local).AddTicks(314),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 763, DateTimeKind.Local).AddTicks(9624));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 614, DateTimeKind.Local).AddTicks(8488),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 795, DateTimeKind.Local).AddTicks(331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 614, DateTimeKind.Local).AddTicks(9190),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 795, DateTimeKind.Local).AddTicks(1037));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 525, DateTimeKind.Local).AddTicks(2881),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 741, DateTimeKind.Local).AddTicks(9303));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 523, DateTimeKind.Local).AddTicks(2668),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 29, 29, 739, DateTimeKind.Local).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "61c6cea1-98ce-48fe-bf02-9295a78e1c85");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b3142a7a-b595-476b-91ad-9326a1f99b4f", "AQAAAAEAACcQAAAAEI376FP8s1HyPmPiAH7ICHYsy43Wa1X/XXLZzZPlHCfYFSIxOgJbjpPTLdeXLUdRHA==" });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "PurchaseDate" },
                values: new object[] { new DateTime(2021, 5, 8, 16, 27, 18, 687, DateTimeKind.Local).AddTicks(2809), new DateTime(2021, 5, 8, 16, 27, 18, 687, DateTimeKind.Local).AddTicks(2172) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 8, 16, 27, 18, 683, DateTimeKind.Local).AddTicks(4145), new DateTime(2021, 5, 8, 16, 27, 18, 683, DateTimeKind.Local).AddTicks(3474) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 8, 16, 27, 18, 683, DateTimeKind.Local).AddTicks(5348), new DateTime(2021, 5, 8, 16, 27, 18, 683, DateTimeKind.Local).AddTicks(5341) });

            migrationBuilder.UpdateData(
                table: "OrderPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 8, 16, 27, 18, 686, DateTimeKind.Local).AddTicks(1404), new DateTime(2021, 5, 8, 16, 27, 18, 686, DateTimeKind.Local).AddTicks(2114) });

            migrationBuilder.UpdateData(
                table: "ProcessPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 8, 16, 27, 18, 689, DateTimeKind.Local).AddTicks(3415), new DateTime(2021, 5, 8, 16, 27, 18, 689, DateTimeKind.Local).AddTicks(4117) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 8, 16, 27, 18, 684, DateTimeKind.Local).AddTicks(7251), new DateTime(2021, 5, 8, 16, 27, 18, 684, DateTimeKind.Local).AddTicks(6611) });
        }
    }
}
