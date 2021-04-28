using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuan.Data.Migrations
{
    public partial class ManageCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeManages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 261, DateTimeKind.Local).AddTicks(3777),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 839, DateTimeKind.Local).AddTicks(311));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 261, DateTimeKind.Local).AddTicks(4187),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 839, DateTimeKind.Local).AddTicks(1001));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 225, DateTimeKind.Local).AddTicks(1096),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 775, DateTimeKind.Local).AddTicks(5056));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 225, DateTimeKind.Local).AddTicks(657),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 775, DateTimeKind.Local).AddTicks(4356));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 235, DateTimeKind.Local).AddTicks(8698),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 791, DateTimeKind.Local).AddTicks(5417));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 235, DateTimeKind.Local).AddTicks(8258),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 791, DateTimeKind.Local).AddTicks(4584));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 255, DateTimeKind.Local).AddTicks(1915),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 829, DateTimeKind.Local).AddTicks(2084));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 255, DateTimeKind.Local).AddTicks(2357),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 829, DateTimeKind.Local).AddTicks(2877));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 219, DateTimeKind.Local).AddTicks(4356),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 766, DateTimeKind.Local).AddTicks(9384));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 217, DateTimeKind.Local).AddTicks(7292),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 764, DateTimeKind.Local).AddTicks(8530));

            migrationBuilder.CreateTable(
                name: "ManageCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Top = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TypeCode = table.Column<int>(type: "int", nullable: false),
                    IdConnect = table.Column<long>(type: "bigint", nullable: false),
                    Location = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManageCodes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "83e485f0-6620-4b53-a85e-5dce82d3d137");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d21be5ca-9b87-4178-9af2-411fa5728fc3", "AQAAAAEAACcQAAAAEICV+HEPABUUK5CiMiGielX8w3XJmS1+4fv2c22ok3K5up984Adm2K9deWOqe86c3w==" });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "PurchaseDate" },
                values: new object[] { new DateTime(2021, 4, 27, 21, 2, 7, 315, DateTimeKind.Local).AddTicks(5370), new DateTime(2021, 4, 27, 21, 2, 7, 315, DateTimeKind.Local).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 4, 27, 21, 2, 7, 308, DateTimeKind.Local).AddTicks(60), new DateTime(2021, 4, 27, 21, 2, 7, 307, DateTimeKind.Local).AddTicks(8780) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 4, 27, 21, 2, 7, 308, DateTimeKind.Local).AddTicks(2600), new DateTime(2021, 4, 27, 21, 2, 7, 308, DateTimeKind.Local).AddTicks(2588) });

            migrationBuilder.UpdateData(
                table: "OrderPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 4, 27, 21, 2, 7, 313, DateTimeKind.Local).AddTicks(2294), new DateTime(2021, 4, 27, 21, 2, 7, 313, DateTimeKind.Local).AddTicks(3674) });

            migrationBuilder.UpdateData(
                table: "ProcessPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 4, 27, 21, 2, 7, 319, DateTimeKind.Local).AddTicks(1930), new DateTime(2021, 4, 27, 21, 2, 7, 319, DateTimeKind.Local).AddTicks(2979) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 4, 27, 21, 2, 7, 310, DateTimeKind.Local).AddTicks(7114), new DateTime(2021, 4, 27, 21, 2, 7, 310, DateTimeKind.Local).AddTicks(5795) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManageCodes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 839, DateTimeKind.Local).AddTicks(311),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 261, DateTimeKind.Local).AddTicks(3777));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 839, DateTimeKind.Local).AddTicks(1001),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 261, DateTimeKind.Local).AddTicks(4187));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 775, DateTimeKind.Local).AddTicks(5056),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 225, DateTimeKind.Local).AddTicks(1096));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 775, DateTimeKind.Local).AddTicks(4356),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 225, DateTimeKind.Local).AddTicks(657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 791, DateTimeKind.Local).AddTicks(5417),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 235, DateTimeKind.Local).AddTicks(8698));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 791, DateTimeKind.Local).AddTicks(4584),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 235, DateTimeKind.Local).AddTicks(8258));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 829, DateTimeKind.Local).AddTicks(2084),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 255, DateTimeKind.Local).AddTicks(1915));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 829, DateTimeKind.Local).AddTicks(2877),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 255, DateTimeKind.Local).AddTicks(2357));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 766, DateTimeKind.Local).AddTicks(9384),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 219, DateTimeKind.Local).AddTicks(4356));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 20, 19, 40, 764, DateTimeKind.Local).AddTicks(8530),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 27, 21, 2, 7, 217, DateTimeKind.Local).AddTicks(7292));

            migrationBuilder.CreateTable(
                name: "CodeManages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdConnect = table.Column<long>(type: "bigint", nullable: false),
                    Location = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Top = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TypeCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeManages", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "22a8fc96-7cb3-4972-856e-b283604e2a5d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cd5c09bc-079a-4516-9ea7-fd6d925fe8ea", "AQAAAAEAACcQAAAAELZU87ptvMg1y19QXimf0G0jxEO/j5Hcq7NbhTvHLHYa3GgyRDo8FIox1OmNPpDY3w==" });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "PurchaseDate" },
                values: new object[] { new DateTime(2021, 4, 27, 20, 19, 40, 920, DateTimeKind.Local).AddTicks(2502), new DateTime(2021, 4, 27, 20, 19, 40, 920, DateTimeKind.Local).AddTicks(1537) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 4, 27, 20, 19, 40, 913, DateTimeKind.Local).AddTicks(7862), new DateTime(2021, 4, 27, 20, 19, 40, 913, DateTimeKind.Local).AddTicks(6793) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 4, 27, 20, 19, 40, 913, DateTimeKind.Local).AddTicks(9893), new DateTime(2021, 4, 27, 20, 19, 40, 913, DateTimeKind.Local).AddTicks(9879) });

            migrationBuilder.UpdateData(
                table: "OrderPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 4, 27, 20, 19, 40, 918, DateTimeKind.Local).AddTicks(3321), new DateTime(2021, 4, 27, 20, 19, 40, 918, DateTimeKind.Local).AddTicks(4458) });

            migrationBuilder.UpdateData(
                table: "ProcessPlans",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ExpectedDate" },
                values: new object[] { new DateTime(2021, 4, 27, 20, 19, 40, 923, DateTimeKind.Local).AddTicks(112), new DateTime(2021, 4, 27, 20, 19, 40, 923, DateTimeKind.Local).AddTicks(1133) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 4, 27, 20, 19, 40, 915, DateTimeKind.Local).AddTicks(9547), new DateTime(2021, 4, 27, 20, 19, 40, 915, DateTimeKind.Local).AddTicks(8218) });
        }
    }
}
