using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 31, 20, 56, 59, 495, DateTimeKind.Local).AddTicks(2712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 26, 23, 38, 4, 339, DateTimeKind.Local).AddTicks(769));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "UserRols",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 31, 20, 56, 59, 495, DateTimeKind.Local).AddTicks(4169),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 26, 23, 38, 4, 339, DateTimeKind.Local).AddTicks(1844));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "RolePermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 31, 20, 56, 59, 495, DateTimeKind.Local).AddTicks(5631),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 26, 23, 38, 4, 339, DateTimeKind.Local).AddTicks(2695));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 26, 23, 38, 4, 339, DateTimeKind.Local).AddTicks(769),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 31, 20, 56, 59, 495, DateTimeKind.Local).AddTicks(2712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "UserRols",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 26, 23, 38, 4, 339, DateTimeKind.Local).AddTicks(1844),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 31, 20, 56, 59, 495, DateTimeKind.Local).AddTicks(4169));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "RolePermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 26, 23, 38, 4, 339, DateTimeKind.Local).AddTicks(2695),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 31, 20, 56, 59, 495, DateTimeKind.Local).AddTicks(5631));

            migrationBuilder.InsertData(
                table: "Rols",
                columns: new[] { "Id", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "RoleName", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { -1, 0, new DateTime(2025, 8, 26, 23, 38, 4, 652, DateTimeKind.Local).AddTicks(6658), true, false, "SuperAdmin", null, null },
                    { 1, 0, new DateTime(2025, 8, 26, 23, 38, 4, 652, DateTimeKind.Local).AddTicks(6836), true, false, "Admin", null, null },
                    { 2, 0, new DateTime(2025, 8, 26, 23, 38, 4, 652, DateTimeKind.Local).AddTicks(6956), true, false, "Manager", null, null },
                    { 3, 0, new DateTime(2025, 8, 26, 23, 38, 4, 652, DateTimeKind.Local).AddTicks(7070), true, false, "User", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "EmailAddress", "FirstName", "ForceChanePassword", "InsertBy", "InsertDate", "IsActive", "LastLoginDate", "LastName", "MobileNumber", "NationalCode", "Password", "PhoneNumber", "Token", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, "user1@test.com", "Mohammad", false, 0, new DateTime(2025, 8, 26, 23, 38, 4, 652, DateTimeKind.Local).AddTicks(9360), true, null, "Zarrabi", "09120198177", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null, null, null },
                    { 2, null, "user2@test.com", "Ali", false, 0, new DateTime(2025, 8, 26, 23, 38, 4, 652, DateTimeKind.Local).AddTicks(9716), true, null, "Rezaei", "09120000002", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null, null, null },
                    { 3, null, "user3@test.com", "Sara", false, 0, new DateTime(2025, 8, 26, 23, 38, 4, 653, DateTimeKind.Local).AddTicks(39), true, null, "Ahmadi", "09120000003", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRols",
                columns: new[] { "Id", "InsertBy", "InsertDate", "RoleId", "UpdateBy", "UpdateDate", "UserId" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2025, 8, 26, 23, 38, 4, 653, DateTimeKind.Local).AddTicks(1837), -1, null, null, 1 },
                    { 2, 0, new DateTime(2025, 8, 26, 23, 38, 4, 653, DateTimeKind.Local).AddTicks(2003), 1, null, null, 1 },
                    { 3, 0, new DateTime(2025, 8, 26, 23, 38, 4, 653, DateTimeKind.Local).AddTicks(2145), 2, null, null, 2 }
                });
        }
    }
}
