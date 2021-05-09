using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuan.Data.Migrations
{
    public partial class Authority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 629, DateTimeKind.Local).AddTicks(8653),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 787, DateTimeKind.Local).AddTicks(3528));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 629, DateTimeKind.Local).AddTicks(9348),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 787, DateTimeKind.Local).AddTicks(3929));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 535, DateTimeKind.Local).AddTicks(1148),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 748, DateTimeKind.Local).AddTicks(701));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 535, DateTimeKind.Local).AddTicks(678),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 748, DateTimeKind.Local).AddTicks(202));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 554, DateTimeKind.Local).AddTicks(1172),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 762, DateTimeKind.Local).AddTicks(5962));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 554, DateTimeKind.Local).AddTicks(314),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 762, DateTimeKind.Local).AddTicks(5439));

            migrationBuilder.AddColumn<Guid>(
                name: "IdAuthority",
                table: "OrderPlans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 614, DateTimeKind.Local).AddTicks(8488),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 779, DateTimeKind.Local).AddTicks(6858));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 614, DateTimeKind.Local).AddTicks(9190),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 779, DateTimeKind.Local).AddTicks(7601));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 525, DateTimeKind.Local).AddTicks(2881),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 741, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 523, DateTimeKind.Local).AddTicks(2668),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 738, DateTimeKind.Local).AddTicks(5098));

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

            migrationBuilder.CreateIndex(
                name: "IX_OrderPlans_IdAuthority",
                table: "OrderPlans",
                column: "IdAuthority");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPlans_AspNetUsers_IdAuthority",
                table: "OrderPlans",
                column: "IdAuthority",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPlans_AspNetUsers_IdAuthority",
                table: "OrderPlans");

            migrationBuilder.DropIndex(
                name: "IX_OrderPlans_IdAuthority",
                table: "OrderPlans");

            migrationBuilder.DropColumn(
                name: "IdAuthority",
                table: "OrderPlans");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 787, DateTimeKind.Local).AddTicks(3528),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 629, DateTimeKind.Local).AddTicks(8653));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 787, DateTimeKind.Local).AddTicks(3929),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 629, DateTimeKind.Local).AddTicks(9348));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 748, DateTimeKind.Local).AddTicks(701),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 535, DateTimeKind.Local).AddTicks(1148));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 748, DateTimeKind.Local).AddTicks(202),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 535, DateTimeKind.Local).AddTicks(678));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 762, DateTimeKind.Local).AddTicks(5962),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 554, DateTimeKind.Local).AddTicks(1172));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 762, DateTimeKind.Local).AddTicks(5439),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 554, DateTimeKind.Local).AddTicks(314));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 779, DateTimeKind.Local).AddTicks(6858),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 614, DateTimeKind.Local).AddTicks(8488));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 779, DateTimeKind.Local).AddTicks(7601),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 614, DateTimeKind.Local).AddTicks(9190));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 741, DateTimeKind.Local).AddTicks(7967),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 525, DateTimeKind.Local).AddTicks(2881));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 7, 21, 55, 30, 738, DateTimeKind.Local).AddTicks(5098),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 8, 16, 27, 18, 523, DateTimeKind.Local).AddTicks(2668));

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
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 7, 21, 55, 30, 837, DateTimeKind.Local).AddTicks(6959), new DateTime(2021, 5, 7, 21, 55, 30, 837, DateTimeKind.Local).AddTicks(7589) });

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
    }
}