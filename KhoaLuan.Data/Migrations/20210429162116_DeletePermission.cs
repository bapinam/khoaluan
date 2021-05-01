using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuan.Data.Migrations
{
    public partial class DeletePermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Permission",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 404, DateTimeKind.Local).AddTicks(1128),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 48, DateTimeKind.Local).AddTicks(4886));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 404, DateTimeKind.Local).AddTicks(1522),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 48, DateTimeKind.Local).AddTicks(5492));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 360, DateTimeKind.Local).AddTicks(7372),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 1, 994, DateTimeKind.Local).AddTicks(1299));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 360, DateTimeKind.Local).AddTicks(5927),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 1, 994, DateTimeKind.Local).AddTicks(516));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 373, DateTimeKind.Local).AddTicks(7273),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 6, DateTimeKind.Local).AddTicks(7386));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 373, DateTimeKind.Local).AddTicks(6455),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 6, DateTimeKind.Local).AddTicks(6574));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 398, DateTimeKind.Local).AddTicks(3264),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 40, DateTimeKind.Local).AddTicks(8699));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 398, DateTimeKind.Local).AddTicks(3713),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 40, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 354, DateTimeKind.Local).AddTicks(2471),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 1, 987, DateTimeKind.Local).AddTicks(6062));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 352, DateTimeKind.Local).AddTicks(6796),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 20, 56, 1, 985, DateTimeKind.Local).AddTicks(9130));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "b61803a6-b576-4eab-8231-21121c4f3007");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7ec82357-92f4-4c6f-b02f-66ba142ea80d", "AQAAAAEAACcQAAAAECM8qb0aqLtsVLe4y1mQLevcf60+lihtnMvXuiEkqaW8xKot4Ai00JdUwkCl/rmxSg==" });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "PurchaseDate" },
                values: new object[] { new DateTime(2021, 4, 29, 23, 21, 14, 450, DateTimeKind.Local).AddTicks(7892), new DateTime(2021, 4, 29, 23, 21, 14, 450, DateTimeKind.Local).AddTicks(7271) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 4, 29, 23, 21, 14, 446, DateTimeKind.Local).AddTicks(9930), new DateTime(2021, 4, 29, 23, 21, 14, 446, DateTimeKind.Local).AddTicks(9279) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 4, 29, 23, 21, 14, 447, DateTimeKind.Local).AddTicks(1095), new DateTime(2021, 4, 29, 23, 21, 14, 447, DateTimeKind.Local).AddTicks(1088) });

            migrationBuilder.UpdateData(
                table: "OrderPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 4, 29, 23, 21, 14, 449, DateTimeKind.Local).AddTicks(6735), new DateTime(2021, 4, 29, 23, 21, 14, 449, DateTimeKind.Local).AddTicks(7376) });

            migrationBuilder.UpdateData(
                table: "ProcessPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 4, 29, 23, 21, 14, 452, DateTimeKind.Local).AddTicks(8504), new DateTime(2021, 4, 29, 23, 21, 14, 452, DateTimeKind.Local).AddTicks(9168) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 4, 29, 23, 21, 14, 448, DateTimeKind.Local).AddTicks(2884), new DateTime(2021, 4, 29, 23, 21, 14, 448, DateTimeKind.Local).AddTicks(2255) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 48, DateTimeKind.Local).AddTicks(4886),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 404, DateTimeKind.Local).AddTicks(1128));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 48, DateTimeKind.Local).AddTicks(5492),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 404, DateTimeKind.Local).AddTicks(1522));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 1, 994, DateTimeKind.Local).AddTicks(1299),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 360, DateTimeKind.Local).AddTicks(7372));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 1, 994, DateTimeKind.Local).AddTicks(516),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 360, DateTimeKind.Local).AddTicks(5927));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 6, DateTimeKind.Local).AddTicks(7386),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 373, DateTimeKind.Local).AddTicks(7273));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 6, DateTimeKind.Local).AddTicks(6574),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 373, DateTimeKind.Local).AddTicks(6455));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 40, DateTimeKind.Local).AddTicks(8699),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 398, DateTimeKind.Local).AddTicks(3264));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 2, 40, DateTimeKind.Local).AddTicks(9370),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 398, DateTimeKind.Local).AddTicks(3713));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 1, 987, DateTimeKind.Local).AddTicks(6062),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 354, DateTimeKind.Local).AddTicks(2471));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 29, 20, 56, 1, 985, DateTimeKind.Local).AddTicks(9130),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 29, 23, 21, 14, 352, DateTimeKind.Local).AddTicks(6796));

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
    }
}
