using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifyDateTimd",
                table: "Permissions",
                newName: "ModifyDateTime");

            migrationBuilder.RenameColumn(
                name: "CreateDareTime",
                table: "Permissions",
                newName: "CreateDateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 17, 23, 45, 20, 973, DateTimeKind.Local).AddTicks(1664),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 17, 23, 9, 26, 850, DateTimeKind.Local).AddTicks(4069));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "UserRols",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 17, 23, 45, 20, 973, DateTimeKind.Local).AddTicks(2712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 17, 23, 9, 26, 850, DateTimeKind.Local).AddTicks(5540));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "RolePermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 17, 23, 45, 20, 973, DateTimeKind.Local).AddTicks(3066),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 17, 23, 9, 26, 850, DateTimeKind.Local).AddTicks(5938));

            migrationBuilder.UpdateData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2025, 8, 17, 23, 45, 21, 247, DateTimeKind.Local).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2025, 8, 17, 23, 45, 21, 247, DateTimeKind.Local).AddTicks(2958));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifyDateTime",
                table: "Permissions",
                newName: "ModifyDateTimd");

            migrationBuilder.RenameColumn(
                name: "CreateDateTime",
                table: "Permissions",
                newName: "CreateDareTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 17, 23, 9, 26, 850, DateTimeKind.Local).AddTicks(4069),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 17, 23, 45, 20, 973, DateTimeKind.Local).AddTicks(1664));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "UserRols",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 17, 23, 9, 26, 850, DateTimeKind.Local).AddTicks(5540),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 17, 23, 45, 20, 973, DateTimeKind.Local).AddTicks(2712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "RolePermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 17, 23, 9, 26, 850, DateTimeKind.Local).AddTicks(5938),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 17, 23, 45, 20, 973, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2025, 8, 17, 23, 9, 27, 87, DateTimeKind.Local).AddTicks(8916));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2025, 8, 17, 23, 9, 27, 87, DateTimeKind.Local).AddTicks(8078));
        }
    }
}
