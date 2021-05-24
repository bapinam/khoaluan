using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuan.Data.Migrations
{
    public partial class ChangeProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingVoucherDetail_Materials_MaterialsId",
                table: "ProcessingVoucherDetail");

            migrationBuilder.RenameColumn(
                name: "MaterialsId",
                table: "ProcessingVoucherDetail",
                newName: "RecipeId");

            migrationBuilder.RenameColumn(
                name: "IdMaterials",
                table: "ProcessingVoucherDetail",
                newName: "IdRecipe");

            migrationBuilder.RenameIndex(
                name: "IX_ProcessingVoucherDetail_MaterialsId",
                table: "ProcessingVoucherDetail",
                newName: "IX_ProcessingVoucherDetail_RecipeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 852, DateTimeKind.Local).AddTicks(4562),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 146, DateTimeKind.Local).AddTicks(2265));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 852, DateTimeKind.Local).AddTicks(4954),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 146, DateTimeKind.Local).AddTicks(2674));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 816, DateTimeKind.Local).AddTicks(9748),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 108, DateTimeKind.Local).AddTicks(5388));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 816, DateTimeKind.Local).AddTicks(9322),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 108, DateTimeKind.Local).AddTicks(4900));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 830, DateTimeKind.Local).AddTicks(7467),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 122, DateTimeKind.Local).AddTicks(9353));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 830, DateTimeKind.Local).AddTicks(6972),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 122, DateTimeKind.Local).AddTicks(8903));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 858, DateTimeKind.Local).AddTicks(2873),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 151, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 846, DateTimeKind.Local).AddTicks(4969),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 138, DateTimeKind.Local).AddTicks(9936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 846, DateTimeKind.Local).AddTicks(5448),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 139, DateTimeKind.Local).AddTicks(358));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 811, DateTimeKind.Local).AddTicks(3192),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 102, DateTimeKind.Local).AddTicks(8039));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 809, DateTimeKind.Local).AddTicks(8551),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 101, DateTimeKind.Local).AddTicks(3367));

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingVoucherDetail_Recipes_RecipeId",
                table: "ProcessingVoucherDetail",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessingVoucherDetail_Recipes_RecipeId",
                table: "ProcessingVoucherDetail");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "ProcessingVoucherDetail",
                newName: "MaterialsId");

            migrationBuilder.RenameColumn(
                name: "IdRecipe",
                table: "ProcessingVoucherDetail",
                newName: "IdMaterials");

            migrationBuilder.RenameIndex(
                name: "IX_ProcessingVoucherDetail_RecipeId",
                table: "ProcessingVoucherDetail",
                newName: "IX_ProcessingVoucherDetail_MaterialsId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 146, DateTimeKind.Local).AddTicks(2265),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 852, DateTimeKind.Local).AddTicks(4562));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 146, DateTimeKind.Local).AddTicks(2674),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 852, DateTimeKind.Local).AddTicks(4954));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 108, DateTimeKind.Local).AddTicks(5388),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 816, DateTimeKind.Local).AddTicks(9748));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 108, DateTimeKind.Local).AddTicks(4900),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 816, DateTimeKind.Local).AddTicks(9322));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 122, DateTimeKind.Local).AddTicks(9353),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 830, DateTimeKind.Local).AddTicks(7467));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 122, DateTimeKind.Local).AddTicks(8903),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 830, DateTimeKind.Local).AddTicks(6972));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 151, DateTimeKind.Local).AddTicks(7772),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 858, DateTimeKind.Local).AddTicks(2873));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 138, DateTimeKind.Local).AddTicks(9936),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 846, DateTimeKind.Local).AddTicks(4969));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 139, DateTimeKind.Local).AddTicks(358),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 846, DateTimeKind.Local).AddTicks(5448));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 102, DateTimeKind.Local).AddTicks(8039),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 811, DateTimeKind.Local).AddTicks(3192));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 101, DateTimeKind.Local).AddTicks(3367),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 24, 4, 48, 18, 809, DateTimeKind.Local).AddTicks(8551));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "f581f9f7-ff7f-4e73-8a4b-a2e9e26fe965");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e8725273-9797-489c-b141-a4f355fdac1a", "AQAAAAEAACcQAAAAEIpHuvwRU7cSyRLaIq8I9HneAw0AA8/Fwwfa5iighLHiFDasPyEYNQHjSmtHm5CJaw==" });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 23, 12, 22, 16, 204, DateTimeKind.Local).AddTicks(5337), new DateTime(2021, 5, 23, 12, 22, 16, 204, DateTimeKind.Local).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 23, 12, 22, 16, 204, DateTimeKind.Local).AddTicks(9342), new DateTime(2021, 5, 23, 12, 22, 16, 204, DateTimeKind.Local).AddTicks(9316) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 23, 12, 22, 16, 207, DateTimeKind.Local).AddTicks(6922), new DateTime(2021, 5, 23, 12, 22, 16, 207, DateTimeKind.Local).AddTicks(5628) });

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessingVoucherDetail_Materials_MaterialsId",
                table: "ProcessingVoucherDetail",
                column: "MaterialsId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
