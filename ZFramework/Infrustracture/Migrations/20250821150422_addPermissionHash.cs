using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPermissionHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 21, 18, 34, 22, 468, DateTimeKind.Local).AddTicks(258),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 21, 14, 21, 30, 420, DateTimeKind.Local).AddTicks(8298));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "UserRols",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 21, 18, 34, 22, 468, DateTimeKind.Local).AddTicks(1379),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 21, 14, 21, 30, 420, DateTimeKind.Local).AddTicks(9350));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "RolePermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 21, 18, 34, 22, 468, DateTimeKind.Local).AddTicks(2277),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 21, 14, 21, 30, 421, DateTimeKind.Local).AddTicks(210));

            migrationBuilder.AddColumn<decimal>(
                name: "PermissionHash",
                table: "Permissions",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2025, 8, 21, 18, 34, 22, 747, DateTimeKind.Local).AddTicks(4035));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "EmailAddress", "FirstName", "ForceChanePassword", "InsertBy", "InsertDate", "IsActive", "LastLoginDate", "LastName", "MobileNumber", "NationalCode", "Password", "PhoneNumber", "Token" },
                values: new object[] { 1, null, "mhzsam@gmail.com", "Mohammad555", false, 0, new DateTime(2025, 8, 21, 18, 34, 22, 748, DateTimeKind.Local).AddTicks(105), false, null, "Zarrabi", "09120198177", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null });

            migrationBuilder.InsertData(
                table: "UserRols",
                columns: new[] { "Id", "InsertBy", "InsertDate", "RoleId", "UserId" },
                values: new object[] { 1, 0, new DateTime(2025, 8, 21, 18, 34, 22, 748, DateTimeKind.Local).AddTicks(2727), 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermissionHash",
                table: "Permissions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 21, 14, 21, 30, 420, DateTimeKind.Local).AddTicks(8298),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 21, 18, 34, 22, 468, DateTimeKind.Local).AddTicks(258));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "UserRols",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 21, 14, 21, 30, 420, DateTimeKind.Local).AddTicks(9350),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 21, 18, 34, 22, 468, DateTimeKind.Local).AddTicks(1379));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "RolePermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 21, 14, 21, 30, 421, DateTimeKind.Local).AddTicks(210),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 21, 18, 34, 22, 468, DateTimeKind.Local).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2025, 8, 21, 14, 21, 30, 782, DateTimeKind.Local).AddTicks(9594));

            migrationBuilder.UpdateData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2025, 8, 21, 14, 21, 30, 784, DateTimeKind.Local).AddTicks(2960));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2025, 8, 21, 14, 21, 30, 783, DateTimeKind.Local).AddTicks(8853));
        }
    }
}
