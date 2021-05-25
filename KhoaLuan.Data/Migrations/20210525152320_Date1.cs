using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuan.Data.Migrations
{
    public partial class Date1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 991, DateTimeKind.Local).AddTicks(1338),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 740, DateTimeKind.Local).AddTicks(8394));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 991, DateTimeKind.Local).AddTicks(1852),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 740, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 926, DateTimeKind.Local).AddTicks(8611),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 699, DateTimeKind.Local).AddTicks(9146));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 926, DateTimeKind.Local).AddTicks(8081),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 699, DateTimeKind.Local).AddTicks(8709));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProcessingVouchers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 25, 22, 23, 18, 5, DateTimeKind.Local).AddTicks(2666),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 751, DateTimeKind.Local).AddTicks(8336));

            migrationBuilder.AddColumn<DateTime>(
                name: "CompleteDate",
                table: "ProcessingVouchers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 25, 22, 23, 18, 5, DateTimeKind.Local).AddTicks(3953));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 948, DateTimeKind.Local).AddTicks(4248),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 714, DateTimeKind.Local).AddTicks(8581));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 948, DateTimeKind.Local).AddTicks(3115),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 714, DateTimeKind.Local).AddTicks(8128));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 999, DateTimeKind.Local).AddTicks(6697),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 748, DateTimeKind.Local).AddTicks(7759));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 978, DateTimeKind.Local).AddTicks(3969),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 731, DateTimeKind.Local).AddTicks(9906));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 978, DateTimeKind.Local).AddTicks(4535),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 732, DateTimeKind.Local).AddTicks(352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 915, DateTimeKind.Local).AddTicks(256),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 694, DateTimeKind.Local).AddTicks(261));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 912, DateTimeKind.Local).AddTicks(8276),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 692, DateTimeKind.Local).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "a67dffe7-cbd5-4b0c-8985-b3215e9868c5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0bb8def6-f758-487d-85d6-9f36b2c1c3a7", "AQAAAAEAACcQAAAAECrFFKU1BaA20OkXYwaVsmtnpIThNUIOpiINdzWVt8nSCMrLg5Heka0EBqEY+XZVeA==" });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 25, 22, 23, 18, 64, DateTimeKind.Local).AddTicks(1701), new DateTime(2021, 5, 25, 22, 23, 18, 64, DateTimeKind.Local).AddTicks(943) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 25, 22, 23, 18, 64, DateTimeKind.Local).AddTicks(3162), new DateTime(2021, 5, 25, 22, 23, 18, 64, DateTimeKind.Local).AddTicks(3155) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 25, 22, 23, 18, 65, DateTimeKind.Local).AddTicks(7161), new DateTime(2021, 5, 25, 22, 23, 18, 65, DateTimeKind.Local).AddTicks(6433) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompleteDate",
                table: "ProcessingVouchers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 740, DateTimeKind.Local).AddTicks(8394),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 991, DateTimeKind.Local).AddTicks(1338));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 740, DateTimeKind.Local).AddTicks(8872),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 991, DateTimeKind.Local).AddTicks(1852));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 699, DateTimeKind.Local).AddTicks(9146),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 926, DateTimeKind.Local).AddTicks(8611));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 699, DateTimeKind.Local).AddTicks(8709),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 926, DateTimeKind.Local).AddTicks(8081));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProcessingVouchers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 751, DateTimeKind.Local).AddTicks(8336),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 25, 22, 23, 18, 5, DateTimeKind.Local).AddTicks(2666));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 714, DateTimeKind.Local).AddTicks(8581),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 948, DateTimeKind.Local).AddTicks(4248));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 714, DateTimeKind.Local).AddTicks(8128),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 948, DateTimeKind.Local).AddTicks(3115));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 748, DateTimeKind.Local).AddTicks(7759),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 999, DateTimeKind.Local).AddTicks(6697));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 731, DateTimeKind.Local).AddTicks(9906),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 978, DateTimeKind.Local).AddTicks(3969));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 732, DateTimeKind.Local).AddTicks(352),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 978, DateTimeKind.Local).AddTicks(4535));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 694, DateTimeKind.Local).AddTicks(261),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 915, DateTimeKind.Local).AddTicks(256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 59, 59, 692, DateTimeKind.Local).AddTicks(4614),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 25, 22, 23, 17, 912, DateTimeKind.Local).AddTicks(8276));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "53c62ea9-b572-4fc5-beb8-5affc2fd638f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1554ae55-dc7c-4dfc-8c37-5fc0a61fd0f7", "AQAAAAEAACcQAAAAEJWaRHq7MR8RfCq+7ogziZa9pYVCfpOswSg1oSng09XUzpWXvWfQM7SwdHBTXSyrxA==" });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 24, 5, 59, 59, 797, DateTimeKind.Local).AddTicks(277), new DateTime(2021, 5, 24, 5, 59, 59, 796, DateTimeKind.Local).AddTicks(9535) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 24, 5, 59, 59, 797, DateTimeKind.Local).AddTicks(1804), new DateTime(2021, 5, 24, 5, 59, 59, 797, DateTimeKind.Local).AddTicks(1797) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 24, 5, 59, 59, 798, DateTimeKind.Local).AddTicks(4850), new DateTime(2021, 5, 24, 5, 59, 59, 798, DateTimeKind.Local).AddTicks(4129) });
        }
    }
}
