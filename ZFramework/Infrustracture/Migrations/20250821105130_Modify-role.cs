using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Modifyrole : Migration
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

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "UserRols");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Rols");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "ModifyDateTime",
                table: "Permissions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 21, 14, 21, 30, 420, DateTimeKind.Local).AddTicks(8298),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 21, 13, 8, 56, 550, DateTimeKind.Local).AddTicks(3245));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "UserRols",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 21, 14, 21, 30, 420, DateTimeKind.Local).AddTicks(9350),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 21, 13, 8, 56, 550, DateTimeKind.Local).AddTicks(4565));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "RolePermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 21, 14, 21, 30, 421, DateTimeKind.Local).AddTicks(210),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 21, 13, 8, 56, 550, DateTimeKind.Local).AddTicks(5399));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2025, 8, 21, 14, 21, 30, 695, DateTimeKind.Local).AddTicks(6821));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "EmailAddress", "FirstName", "ForceChanePassword", "InsertBy", "InsertDate", "IsActive", "LastLoginDate", "LastName", "MobileNumber", "NationalCode", "Password", "PhoneNumber", "Token" },
                values: new object[] { 1, null, "mhzsam@gmail.com", "Mohammad555", false, 0, new DateTime(2025, 8, 21, 14, 21, 30, 696, DateTimeKind.Local).AddTicks(3917), false, null, "Zarrabi", "09120198177", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null });

            migrationBuilder.InsertData(
                table: "UserRols",
                columns: new[] { "Id", "InsertBy", "InsertDate", "RoleId", "UserId" },
                values: new object[] { 1, 0, new DateTime(2025, 8, 21, 14, 21, 30, 696, DateTimeKind.Local).AddTicks(6866), 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Permissions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 21, 13, 8, 56, 550, DateTimeKind.Local).AddTicks(3245),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 21, 14, 21, 30, 420, DateTimeKind.Local).AddTicks(8298));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "UserRols",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 21, 13, 8, 56, 550, DateTimeKind.Local).AddTicks(4565),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 21, 14, 21, 30, 420, DateTimeKind.Local).AddTicks(9350));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "UserRols",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Rols",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "RolePermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 21, 13, 8, 56, 550, DateTimeKind.Local).AddTicks(5399),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 21, 14, 21, 30, 421, DateTimeKind.Local).AddTicks(210));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "RolePermissions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "Permissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Permissions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDateTime",
                table: "Permissions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeletedDate", "InsertDate" },
                values: new object[] { null, new DateTime(2025, 8, 21, 13, 8, 56, 857, DateTimeKind.Local).AddTicks(952) });

            migrationBuilder.UpdateData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeletedDate", "InsertDate" },
                values: new object[] { null, new DateTime(2025, 8, 21, 13, 8, 56, 857, DateTimeKind.Local).AddTicks(4616) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeletedDate", "InsertDate" },
                values: new object[] { null, new DateTime(2025, 8, 21, 13, 8, 56, 857, DateTimeKind.Local).AddTicks(3060) });
        }
    }
}
