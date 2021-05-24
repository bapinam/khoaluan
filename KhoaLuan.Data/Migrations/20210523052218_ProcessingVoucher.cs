using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuan.Data.Migrations
{
    public partial class ProcessingVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 146, DateTimeKind.Local).AddTicks(2265),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 865, DateTimeKind.Local).AddTicks(7627));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 146, DateTimeKind.Local).AddTicks(2674),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 865, DateTimeKind.Local).AddTicks(8998));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 108, DateTimeKind.Local).AddTicks(5388),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 826, DateTimeKind.Local).AddTicks(5677));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 108, DateTimeKind.Local).AddTicks(4900),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 826, DateTimeKind.Local).AddTicks(5205));

            migrationBuilder.AddColumn<int>(
                name: "EnterAmount",
                table: "ProcessingDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 122, DateTimeKind.Local).AddTicks(9353),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 841, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 122, DateTimeKind.Local).AddTicks(8903),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 841, DateTimeKind.Local).AddTicks(7766));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 151, DateTimeKind.Local).AddTicks(7772),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 872, DateTimeKind.Local).AddTicks(3894));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 138, DateTimeKind.Local).AddTicks(9936),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 858, DateTimeKind.Local).AddTicks(3209));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 139, DateTimeKind.Local).AddTicks(358),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 858, DateTimeKind.Local).AddTicks(3620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 102, DateTimeKind.Local).AddTicks(8039),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 820, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 101, DateTimeKind.Local).AddTicks(3367),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 819, DateTimeKind.Local).AddTicks(2864));

            migrationBuilder.CreateTable(
                name: "ProcessingVoucher",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPlan = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessPlanId = table.Column<long>(type: "bigint", nullable: true),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdCreator = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessingVoucher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessingVoucher_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProcessingVoucher_ProcessPlans_ProcessPlanId",
                        column: x => x.ProcessPlanId,
                        principalTable: "ProcessPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProcessingVoucherDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMaterials = table.Column<int>(type: "int", nullable: false),
                    MaterialsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessingVoucherDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessingVoucherDetail_Materials_MaterialsId",
                        column: x => x.MaterialsId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingVoucher_CreatorId",
                table: "ProcessingVoucher",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingVoucher_ProcessPlanId",
                table: "ProcessingVoucher",
                column: "ProcessPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingVoucherDetail_MaterialsId",
                table: "ProcessingVoucherDetail",
                column: "MaterialsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessingVoucher");

            migrationBuilder.DropTable(
                name: "ProcessingVoucherDetail");

            migrationBuilder.DropColumn(
                name: "EnterAmount",
                table: "ProcessingDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 865, DateTimeKind.Local).AddTicks(7627),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 146, DateTimeKind.Local).AddTicks(2265));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 865, DateTimeKind.Local).AddTicks(8998),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 146, DateTimeKind.Local).AddTicks(2674));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 826, DateTimeKind.Local).AddTicks(5677),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 108, DateTimeKind.Local).AddTicks(5388));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProcessPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 826, DateTimeKind.Local).AddTicks(5205),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 108, DateTimeKind.Local).AddTicks(4900));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 841, DateTimeKind.Local).AddTicks(8184),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 122, DateTimeKind.Local).AddTicks(9353));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 841, DateTimeKind.Local).AddTicks(7766),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 122, DateTimeKind.Local).AddTicks(8903));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 872, DateTimeKind.Local).AddTicks(3894),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 151, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderStartDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 858, DateTimeKind.Local).AddTicks(3209),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 138, DateTimeKind.Local).AddTicks(9936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReminderEndDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 858, DateTimeKind.Local).AddTicks(3620),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 139, DateTimeKind.Local).AddTicks(358));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 820, DateTimeKind.Local).AddTicks(8182),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 102, DateTimeKind.Local).AddTicks(8039));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 21, 14, 16, 19, 819, DateTimeKind.Local).AddTicks(2864),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 23, 12, 22, 16, 101, DateTimeKind.Local).AddTicks(3367));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88a28f0b-99cd-4893-ab70-0189c8c7fec5"),
                column: "ConcurrencyStamp",
                value: "a4d10c53-42fc-423d-a375-29f2e0f84e03");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0275d5a7-da4a-41c3-85ed-15e53cd1b7a0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ae5cc740-9e22-4007-91ac-b8001d258bff", "AQAAAAEAACcQAAAAEI20QoH6W9IhIU32THJX5rPGDk4/D8SLmWxWuySOvjnpwVCaQ0rLDVD0KAOEEaOJRw==" });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 21, 14, 16, 19, 927, DateTimeKind.Local).AddTicks(8315), new DateTime(2021, 5, 21, 14, 16, 19, 927, DateTimeKind.Local).AddTicks(7491) });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 21, 14, 16, 19, 928, DateTimeKind.Local).AddTicks(106), new DateTime(2021, 5, 21, 14, 16, 19, 928, DateTimeKind.Local).AddTicks(96) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReminderEndDate", "ReminderStartDate" },
                values: new object[] { new DateTime(2021, 5, 21, 14, 16, 19, 929, DateTimeKind.Local).AddTicks(5439), new DateTime(2021, 5, 21, 14, 16, 19, 929, DateTimeKind.Local).AddTicks(4651) });
        }
    }
}