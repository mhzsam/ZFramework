using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
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
                defaultValue: new DateTime(2025, 8, 22, 13, 27, 50, 394, DateTimeKind.Local).AddTicks(8905),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 21, 18, 34, 22, 468, DateTimeKind.Local).AddTicks(258));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "UserRols",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 22, 13, 27, 50, 395, DateTimeKind.Local).AddTicks(111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 21, 18, 34, 22, 468, DateTimeKind.Local).AddTicks(1379));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "RolePermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 22, 13, 27, 50, 395, DateTimeKind.Local).AddTicks(955),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 21, 18, 34, 22, 468, DateTimeKind.Local).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2025, 8, 22, 13, 27, 50, 648, DateTimeKind.Local).AddTicks(3732));

            migrationBuilder.InsertData(
                table: "Rols",
                columns: new[] { "Id", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "RoleName", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 2, 0, new DateTime(2025, 8, 22, 13, 27, 50, 648, DateTimeKind.Local).AddTicks(5909), true, false, "Admin", null, null },
                    { 3, 0, new DateTime(2025, 8, 22, 13, 27, 50, 648, DateTimeKind.Local).AddTicks(6466), true, false, "Manager", null, null },
                    { 4, 0, new DateTime(2025, 8, 22, 13, 27, 50, 648, DateTimeKind.Local).AddTicks(6917), true, false, "User", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "EmailAddress", "FirstName", "ForceChanePassword", "InsertBy", "InsertDate", "IsActive", "LastLoginDate", "LastName", "MobileNumber", "NationalCode", "Password", "PhoneNumber", "Token" },
                values: new object[,]
                {
                    { 1, null, "user1@test.com", "Mohammad", false, 0, new DateTime(2025, 8, 22, 13, 27, 50, 649, DateTimeKind.Local).AddTicks(913), false, null, "Zarrabi", "09120000001", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null },
                    { 2, null, "user2@test.com", "Ali", false, 0, new DateTime(2025, 8, 22, 13, 27, 50, 649, DateTimeKind.Local).AddTicks(2103), false, null, "Rezaei", "09120000002", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null },
                    { 3, null, "user3@test.com", "Sara", false, 0, new DateTime(2025, 8, 22, 13, 27, 50, 649, DateTimeKind.Local).AddTicks(3202), false, null, "Ahmadi", "09120000003", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null },
                    { 4, null, "user4@test.com", "Hossein", false, 0, new DateTime(2025, 8, 22, 13, 27, 50, 649, DateTimeKind.Local).AddTicks(4301), false, null, "Karimi", "09120000004", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null },
                    { 5, null, "user5@test.com", "Mina", false, 0, new DateTime(2025, 8, 22, 13, 27, 50, 649, DateTimeKind.Local).AddTicks(5391), false, null, "Rahimi", "09120000005", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null },
                    { 6, null, "user6@test.com", "Reza", false, 0, new DateTime(2025, 8, 22, 13, 27, 50, 649, DateTimeKind.Local).AddTicks(6659), false, null, "Akbari", "09120000006", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null },
                    { 7, null, "user7@test.com", "Neda", false, 0, new DateTime(2025, 8, 22, 13, 27, 50, 649, DateTimeKind.Local).AddTicks(7839), false, null, "Moradi", "09120000007", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null },
                    { 8, null, "user8@test.com", "Hamed", false, 0, new DateTime(2025, 8, 22, 13, 27, 50, 649, DateTimeKind.Local).AddTicks(8934), false, null, "Kazemi", "09120000008", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null },
                    { 9, null, "user9@test.com", "Maryam", false, 0, new DateTime(2025, 8, 22, 13, 27, 50, 650, DateTimeKind.Local).AddTicks(22), false, null, "Shahbazi", "09120000009", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null },
                    { 10, null, "user10@test.com", "Farid", false, 0, new DateTime(2025, 8, 22, 13, 27, 50, 650, DateTimeKind.Local).AddTicks(1100), false, null, "Taheri", "09120000010", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRols",
                columns: new[] { "Id", "InsertBy", "InsertDate", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2025, 8, 22, 13, 27, 50, 650, DateTimeKind.Local).AddTicks(3148), 1, 1 },
                    { 2, 0, new DateTime(2025, 8, 22, 13, 27, 50, 650, DateTimeKind.Local).AddTicks(3864), 2, 2 },
                    { 3, 0, new DateTime(2025, 8, 22, 13, 27, 50, 650, DateTimeKind.Local).AddTicks(4551), 4, 3 },
                    { 4, 0, new DateTime(2025, 8, 22, 13, 27, 50, 650, DateTimeKind.Local).AddTicks(5240), 3, 4 },
                    { 5, 0, new DateTime(2025, 8, 22, 13, 27, 50, 650, DateTimeKind.Local).AddTicks(5925), 4, 5 },
                    { 6, 0, new DateTime(2025, 8, 22, 13, 27, 50, 650, DateTimeKind.Local).AddTicks(6608), 2, 6 },
                    { 7, 0, new DateTime(2025, 8, 22, 13, 27, 50, 650, DateTimeKind.Local).AddTicks(7292), 4, 7 },
                    { 8, 0, new DateTime(2025, 8, 22, 13, 27, 50, 650, DateTimeKind.Local).AddTicks(7972), 3, 8 },
                    { 9, 0, new DateTime(2025, 8, 22, 13, 27, 50, 650, DateTimeKind.Local).AddTicks(8656), 4, 9 },
                    { 10, 0, new DateTime(2025, 8, 22, 13, 27, 50, 650, DateTimeKind.Local).AddTicks(9345), 2, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 21, 18, 34, 22, 468, DateTimeKind.Local).AddTicks(258),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 22, 13, 27, 50, 394, DateTimeKind.Local).AddTicks(8905));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "UserRols",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 21, 18, 34, 22, 468, DateTimeKind.Local).AddTicks(1379),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 22, 13, 27, 50, 395, DateTimeKind.Local).AddTicks(111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "RolePermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 21, 18, 34, 22, 468, DateTimeKind.Local).AddTicks(2277),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 22, 13, 27, 50, 395, DateTimeKind.Local).AddTicks(955));

            migrationBuilder.UpdateData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2025, 8, 21, 18, 34, 22, 816, DateTimeKind.Local).AddTicks(6947));

            migrationBuilder.UpdateData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2025, 8, 21, 18, 34, 22, 817, DateTimeKind.Local).AddTicks(146));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailAddress", "FirstName", "InsertDate", "MobileNumber" },
                values: new object[] { "mhzsam@gmail.com", "Mohammad555", new DateTime(2025, 8, 21, 18, 34, 22, 816, DateTimeKind.Local).AddTicks(9058), "09120198177" });
        }
    }
}
