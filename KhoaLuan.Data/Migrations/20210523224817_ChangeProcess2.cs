using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuan.Data.Migrations
{
    public partial class ChangeProcess2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 932, DateTimeKind.Local).AddTicks(1587),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 852, DateTimeKind.Local).AddTicks(4562));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 932, DateTimeKind.Local).AddTicks(2368),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 852, DateTimeKind.Local).AddTicks(4954));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 875, DateTimeKind.Local).AddTicks(5808),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 816, DateTimeKind.Local).AddTicks(9748));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 875, DateTimeKind.Local).AddTicks(5180),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 816, DateTimeKind.Local).AddTicks(9322));

            migrationBuilder.AddColumn<int>(
                name: "IdVoucher",
                table: "ProcessingVoucherDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ProcessingVoucherId",
                table: "ProcessingVoucherDetail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 898, DateTimeKind.Local).AddTicks(507),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 830, DateTimeKind.Local).AddTicks(7467));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 897, DateTimeKind.Local).AddTicks(9821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 830, DateTimeKind.Local).AddTicks(6972));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 943, DateTimeKind.Local).AddTicks(110),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 858, DateTimeKind.Local).AddTicks(2873));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 921, DateTimeKind.Local).AddTicks(7789),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 846, DateTimeKind.Local).AddTicks(4969));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 921, DateTimeKind.Local).AddTicks(8242),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 846, DateTimeKind.Local).AddTicks(5448));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 867, DateTimeKind.Local).AddTicks(5357),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 811, DateTimeKind.Local).AddTicks(3192));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 866, DateTimeKind.Local).AddTicks(498),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 809, DateTimeKind.Local).AddTicks(8551));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "83fd3a2b-64e1-4fc7-a4c9-200451cdfc41");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a79bdafc-6559-40df-a319-e4d623e9dd3b", "AQAAAAEAACcQAAAAEGku5Y7GxbVbltk7/BySNKQyG6sEBYvDXqqCEY42ooVtskaKSJLVnMhswbwkZljBNw==" });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 24, 5, 48, 14, 999, DateTimeKind.Local).AddTicks(8960), new DateTime(2021, 5, 24, 5, 48, 14, 999, DateTimeKind.Local).AddTicks(8219) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 24, 5, 48, 15, 0, DateTimeKind.Local).AddTicks(534), new DateTime(2021, 5, 24, 5, 48, 15, 0, DateTimeKind.Local).AddTicks(522) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 24, 5, 48, 15, 1, DateTimeKind.Local).AddTicks(8793), new DateTime(2021, 5, 24, 5, 48, 15, 1, DateTimeKind.Local).AddTicks(7208) });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingVoucherDetail_ProcessingVoucherId",
                table: "ProcessingVoucherDetail",
                column: "ProcessingVoucherId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingVoucherDetail_ProcessingVoucher_ProcessingVoucherId",
                table: "ProcessingVoucherDetail",
                column: "ProcessingVoucherId",
                principalTable: "ProcessingVoucher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingVoucherDetail_ProcessingVoucher_ProcessingVoucherId",
                table: "ProcessingVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_ProcessingVoucherDetail_ProcessingVoucherId",
                table: "ProcessingVoucherDetail");

            migrationBuilder.DropColumn(
                name: "IdVoucher",
                table: "ProcessingVoucherDetail");

            migrationBuilder.DropColumn(
                name: "ProcessingVoucherId",
                table: "ProcessingVoucherDetail");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 852, DateTimeKind.Local).AddTicks(4562),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 932, DateTimeKind.Local).AddTicks(1587));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 852, DateTimeKind.Local).AddTicks(4954),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 932, DateTimeKind.Local).AddTicks(2368));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 816, DateTimeKind.Local).AddTicks(9748),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 875, DateTimeKind.Local).AddTicks(5808));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 816, DateTimeKind.Local).AddTicks(9322),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 875, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 830, DateTimeKind.Local).AddTicks(7467),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 898, DateTimeKind.Local).AddTicks(507));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 830, DateTimeKind.Local).AddTicks(6972),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 897, DateTimeKind.Local).AddTicks(9821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 858, DateTimeKind.Local).AddTicks(2873),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 943, DateTimeKind.Local).AddTicks(110));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 846, DateTimeKind.Local).AddTicks(4969),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 921, DateTimeKind.Local).AddTicks(7789));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 846, DateTimeKind.Local).AddTicks(5448),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 921, DateTimeKind.Local).AddTicks(8242));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 811, DateTimeKind.Local).AddTicks(3192),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 867, DateTimeKind.Local).AddTicks(5357));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 809, DateTimeKind.Local).AddTicks(8551),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 5, 48, 14, 866, DateTimeKind.Local).AddTicks(498));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "bb30e080-9008-4846-82b2-0e6af5b6a938");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5270fb05-6a7f-4756-bfee-b49d574886e2", "AQAAAAEAACcQAAAAELrM5K3O5k3HEzffp9qwWp6gALD271dFDzIlx5pyfHhIamV03Gh3tEUK912D4ThwAg==" });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 24, 4, 48, 18, 908, DateTimeKind.Local).AddTicks(4830), new DateTime(2021, 5, 24, 4, 48, 18, 908, DateTimeKind.Local).AddTicks(3625) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 24, 4, 48, 18, 908, DateTimeKind.Local).AddTicks(7159), new DateTime(2021, 5, 24, 4, 48, 18, 908, DateTimeKind.Local).AddTicks(7147) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 24, 4, 48, 18, 910, DateTimeKind.Local).AddTicks(9045), new DateTime(2021, 5, 24, 4, 48, 18, 910, DateTimeKind.Local).AddTicks(7895) });
        }
    }
}
