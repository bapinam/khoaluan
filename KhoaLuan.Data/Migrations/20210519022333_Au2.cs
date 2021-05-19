using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuan.Data.Migrations
{
    public partial class Au2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 993, DateTimeKind.Local).AddTicks(4597),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 61, DateTimeKind.Local).AddTicks(5689));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 993, DateTimeKind.Local).AddTicks(5029),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 61, DateTimeKind.Local).AddTicks(6165));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 931, DateTimeKind.Local).AddTicks(1593),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 6, DateTimeKind.Local).AddTicks(7055));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 931, DateTimeKind.Local).AddTicks(1134),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 6, DateTimeKind.Local).AddTicks(6621));

            migrationBuilder.AddColumn<Guid>(
                name: "IdAuthority",
                table: "ProcessPlans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 960, DateTimeKind.Local).AddTicks(3756),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 30, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 960, DateTimeKind.Local).AddTicks(3287),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 30, DateTimeKind.Local).AddTicks(7375));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 987, DateTimeKind.Local).AddTicks(368),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 54, DateTimeKind.Local).AddTicks(9366));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 987, DateTimeKind.Local).AddTicks(939),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 55, DateTimeKind.Local).AddTicks(581));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 924, DateTimeKind.Local).AddTicks(7209),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 7, 999, DateTimeKind.Local).AddTicks(5548));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 923, DateTimeKind.Local).AddTicks(2237),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 18, 19, 6, 7, 997, DateTimeKind.Local).AddTicks(6825));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "48b857df-d7b5-4e55-a949-3ce4ab179392");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f9c840fe-8621-403a-9a05-aabe055db5a5", "AQAAAAEAACcQAAAAEBmaDI5FZX0UhvNmtRjzRxbs3bPBsdTBEGJE6aWjtUYkyyrsD0eM3W0SMojAbQwVWw==" });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "PurchaseDate" },
                values: new object[] { new DateTime(2021, 5, 19, 9, 23, 31, 55, DateTimeKind.Local).AddTicks(5040), new DateTime(2021, 5, 19, 9, 23, 31, 55, DateTimeKind.Local).AddTicks(4267) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 19, 9, 23, 31, 49, DateTimeKind.Local).AddTicks(5409), new DateTime(2021, 5, 19, 9, 23, 31, 49, DateTimeKind.Local).AddTicks(3983) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 19, 9, 23, 31, 49, DateTimeKind.Local).AddTicks(7850), new DateTime(2021, 5, 19, 9, 23, 31, 49, DateTimeKind.Local).AddTicks(7836) });

            migrationBuilder.UpdateData(
                table: "OrderPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 19, 9, 23, 31, 53, DateTimeKind.Local).AddTicks(4685), new DateTime(2021, 5, 19, 9, 23, 31, 53, DateTimeKind.Local).AddTicks(6041) });

            migrationBuilder.UpdateData(
                table: "ProcessPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 19, 9, 23, 31, 58, DateTimeKind.Local).AddTicks(4096), new DateTime(2021, 5, 19, 9, 23, 31, 58, DateTimeKind.Local).AddTicks(4994) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 19, 9, 23, 31, 51, DateTimeKind.Local).AddTicks(6061), new DateTime(2021, 5, 19, 9, 23, 31, 51, DateTimeKind.Local).AddTicks(5054) });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessPlans_IdAuthority",
                table: "ProcessPlans",
                column: "IdAuthority");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessPlans_AspNetUsers_IdAuthority",
                table: "ProcessPlans",
                column: "IdAuthority",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessPlans_AspNetUsers_IdAuthority",
                table: "ProcessPlans");

            migrationBuilder.DropIndex(
                name: "IX_ProcessPlans_IdAuthority",
                table: "ProcessPlans");

            migrationBuilder.DropColumn(
                name: "IdAuthority",
                table: "ProcessPlans");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 61, DateTimeKind.Local).AddTicks(5689),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 993, DateTimeKind.Local).AddTicks(4597));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 61, DateTimeKind.Local).AddTicks(6165),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 993, DateTimeKind.Local).AddTicks(5029));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 6, DateTimeKind.Local).AddTicks(7055),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 931, DateTimeKind.Local).AddTicks(1593));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 6, DateTimeKind.Local).AddTicks(6621),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 931, DateTimeKind.Local).AddTicks(1134));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 30, DateTimeKind.Local).AddTicks(8030),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 960, DateTimeKind.Local).AddTicks(3756));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 30, DateTimeKind.Local).AddTicks(7375),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 960, DateTimeKind.Local).AddTicks(3287));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 54, DateTimeKind.Local).AddTicks(9366),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 987, DateTimeKind.Local).AddTicks(368));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 8, 55, DateTimeKind.Local).AddTicks(581),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 987, DateTimeKind.Local).AddTicks(939));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 7, 999, DateTimeKind.Local).AddTicks(5548),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 924, DateTimeKind.Local).AddTicks(7209));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 18, 19, 6, 7, 997, DateTimeKind.Local).AddTicks(6825),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 19, 9, 23, 30, 923, DateTimeKind.Local).AddTicks(2237));

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
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 5, 18, 19, 6, 8, 131, DateTimeKind.Local).AddTicks(1993), new DateTime(2021, 5, 18, 19, 6, 8, 131, DateTimeKind.Local).AddTicks(3172) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 18, 19, 6, 8, 120, DateTimeKind.Local).AddTicks(15), new DateTime(2021, 5, 18, 19, 6, 8, 119, DateTimeKind.Local).AddTicks(9019) });
        }
    }
}
