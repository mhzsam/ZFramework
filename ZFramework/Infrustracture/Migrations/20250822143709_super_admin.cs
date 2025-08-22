using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class super_admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

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
                defaultValue: new DateTime(2025, 8, 22, 18, 7, 8, 803, DateTimeKind.Local).AddTicks(7439),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 22, 13, 27, 50, 394, DateTimeKind.Local).AddTicks(8905));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "UserRols",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 22, 18, 7, 8, 803, DateTimeKind.Local).AddTicks(8791),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 22, 13, 27, 50, 395, DateTimeKind.Local).AddTicks(111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "RolePermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 22, 18, 7, 8, 803, DateTimeKind.Local).AddTicks(9697),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 22, 13, 27, 50, 395, DateTimeKind.Local).AddTicks(955));

            migrationBuilder.UpdateData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertDate", "RoleName" },
                values: new object[] { new DateTime(2025, 8, 22, 18, 7, 9, 80, DateTimeKind.Local).AddTicks(3553), "Admin" });

            migrationBuilder.UpdateData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertDate", "RoleName" },
                values: new object[] { new DateTime(2025, 8, 22, 18, 7, 9, 80, DateTimeKind.Local).AddTicks(4415), "Manager" });

            migrationBuilder.UpdateData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InsertDate", "RoleName" },
                values: new object[] { new DateTime(2025, 8, 22, 18, 7, 9, 80, DateTimeKind.Local).AddTicks(4922), "User" });

            migrationBuilder.InsertData(
                table: "Rols",
                columns: new[] { "Id", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "RoleName", "UpdateBy", "UpdateDate" },
                values: new object[] { -1, 0, new DateTime(2025, 8, 22, 18, 7, 9, 80, DateTimeKind.Local).AddTicks(944), true, false, "SuperAdmin", null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "EmailAddress", "FirstName", "ForceChanePassword", "InsertBy", "InsertDate", "IsActive", "LastLoginDate", "LastName", "MobileNumber", "NationalCode", "Password", "PhoneNumber", "Token" },
                values: new object[,]
                {
                    { 1, null, "user1@test.com", "Mohammad", false, 0, new DateTime(2025, 8, 22, 18, 7, 9, 80, DateTimeKind.Local).AddTicks(9903), false, null, "Zarrabi", "09120198177", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null },
                    { 2, null, "user2@test.com", "Ali", false, 0, new DateTime(2025, 8, 22, 18, 7, 9, 81, DateTimeKind.Local).AddTicks(1275), false, null, "Rezaei", "09120000002", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null },
                    { 3, null, "user3@test.com", "Sara", false, 0, new DateTime(2025, 8, 22, 18, 7, 9, 81, DateTimeKind.Local).AddTicks(2457), false, null, "Ahmadi", "09120000003", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null },
                    { 4, null, "user4@test.com", "Hossein", false, 0, new DateTime(2025, 8, 22, 18, 7, 9, 81, DateTimeKind.Local).AddTicks(3696), false, null, "Karimi", "09120000004", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null },
                    { 5, null, "user5@test.com", "Mina", false, 0, new DateTime(2025, 8, 22, 18, 7, 9, 81, DateTimeKind.Local).AddTicks(4854), false, null, "Rahimi", "09120000005", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null },
                    { 6, null, "user6@test.com", "Reza", false, 0, new DateTime(2025, 8, 22, 18, 7, 9, 81, DateTimeKind.Local).AddTicks(6340), false, null, "Akbari", "09120000006", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null },
                    { 7, null, "user7@test.com", "Neda", false, 0, new DateTime(2025, 8, 22, 18, 7, 9, 81, DateTimeKind.Local).AddTicks(7499), false, null, "Moradi", "09120000007", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null },
                    { 8, null, "user8@test.com", "Hamed", false, 0, new DateTime(2025, 8, 22, 18, 7, 9, 81, DateTimeKind.Local).AddTicks(8698), false, null, "Kazemi", "09120000008", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null },
                    { 9, null, "user9@test.com", "Maryam", false, 0, new DateTime(2025, 8, 22, 18, 7, 9, 81, DateTimeKind.Local).AddTicks(9845), false, null, "Shahbazi", "09120000009", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null },
                    { 10, null, "user10@test.com", "Farid", false, 0, new DateTime(2025, 8, 22, 18, 7, 9, 82, DateTimeKind.Local).AddTicks(1144), false, null, "Taheri", "09120000010", null, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRols",
                columns: new[] { "Id", "InsertBy", "InsertDate", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2025, 8, 22, 18, 7, 9, 82, DateTimeKind.Local).AddTicks(5162), -1, 1 },
                    { 2, 0, new DateTime(2025, 8, 22, 18, 7, 9, 82, DateTimeKind.Local).AddTicks(6031), 1, 1 },
                    { 3, 0, new DateTime(2025, 8, 22, 18, 7, 9, 82, DateTimeKind.Local).AddTicks(6769), 2, 2 },
                    { 4, 0, new DateTime(2025, 8, 22, 18, 7, 9, 82, DateTimeKind.Local).AddTicks(7592), 1, 3 },
                    { 5, 0, new DateTime(2025, 8, 22, 18, 7, 9, 82, DateTimeKind.Local).AddTicks(8336), 3, 4 },
                    { 6, 0, new DateTime(2025, 8, 22, 18, 7, 9, 82, DateTimeKind.Local).AddTicks(9107), 2, 5 },
                    { 7, 0, new DateTime(2025, 8, 22, 18, 7, 9, 82, DateTimeKind.Local).AddTicks(9838), 2, 6 },
                    { 8, 0, new DateTime(2025, 8, 22, 18, 7, 9, 83, DateTimeKind.Local).AddTicks(765), 3, 7 },
                    { 9, 0, new DateTime(2025, 8, 22, 18, 7, 9, 83, DateTimeKind.Local).AddTicks(1879), 3, 8 },
                    { 10, 0, new DateTime(2025, 8, 22, 18, 7, 9, 83, DateTimeKind.Local).AddTicks(2638), 3, 9 },
                    { 11, 0, new DateTime(2025, 8, 22, 18, 7, 9, 83, DateTimeKind.Local).AddTicks(3376), 2, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 22, 13, 27, 50, 394, DateTimeKind.Local).AddTicks(8905),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 22, 18, 7, 8, 803, DateTimeKind.Local).AddTicks(7439));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "UserRols",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 22, 13, 27, 50, 395, DateTimeKind.Local).AddTicks(111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 22, 18, 7, 8, 803, DateTimeKind.Local).AddTicks(8791));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "RolePermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 22, 13, 27, 50, 395, DateTimeKind.Local).AddTicks(955),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 22, 18, 7, 8, 803, DateTimeKind.Local).AddTicks(9697));

            migrationBuilder.UpdateData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertDate", "RoleName" },
                values: new object[] { new DateTime(2025, 8, 22, 13, 27, 50, 725, DateTimeKind.Local).AddTicks(2786), "SuperAdmin" });

            migrationBuilder.UpdateData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertDate", "RoleName" },
                values: new object[] { new DateTime(2025, 8, 22, 13, 27, 50, 725, DateTimeKind.Local).AddTicks(2947), "Admin" });

            migrationBuilder.UpdateData(
                table: "Rols",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InsertDate", "RoleName" },
                values: new object[] { new DateTime(2025, 8, 22, 13, 27, 50, 725, DateTimeKind.Local).AddTicks(3059), "Manager" });

            migrationBuilder.InsertData(
                table: "Rols",
                columns: new[] { "Id", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "RoleName", "UpdateBy", "UpdateDate" },
                values: new object[] { 4, 0, new DateTime(2025, 8, 22, 13, 27, 50, 725, DateTimeKind.Local).AddTicks(3179), true, false, "User", null, null });

            migrationBuilder.UpdateData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertDate", "RoleId" },
                values: new object[] { new DateTime(2025, 8, 22, 13, 27, 50, 726, DateTimeKind.Local).AddTicks(533), 1 });

            migrationBuilder.UpdateData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertDate", "RoleId", "UserId" },
                values: new object[] { new DateTime(2025, 8, 22, 13, 27, 50, 726, DateTimeKind.Local).AddTicks(713), 2, 2 });

            migrationBuilder.UpdateData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InsertDate", "RoleId", "UserId" },
                values: new object[] { new DateTime(2025, 8, 22, 13, 27, 50, 726, DateTimeKind.Local).AddTicks(848), 4, 3 });

            migrationBuilder.UpdateData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InsertDate", "RoleId", "UserId" },
                values: new object[] { new DateTime(2025, 8, 22, 13, 27, 50, 726, DateTimeKind.Local).AddTicks(990), 3, 4 });

            migrationBuilder.UpdateData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "InsertDate", "RoleId", "UserId" },
                values: new object[] { new DateTime(2025, 8, 22, 13, 27, 50, 726, DateTimeKind.Local).AddTicks(1119), 4, 5 });

            migrationBuilder.UpdateData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "InsertDate", "UserId" },
                values: new object[] { new DateTime(2025, 8, 22, 13, 27, 50, 726, DateTimeKind.Local).AddTicks(1248), 6 });

            migrationBuilder.UpdateData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "InsertDate", "RoleId", "UserId" },
                values: new object[] { new DateTime(2025, 8, 22, 13, 27, 50, 726, DateTimeKind.Local).AddTicks(1374), 4, 7 });

            migrationBuilder.UpdateData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "InsertDate", "UserId" },
                values: new object[] { new DateTime(2025, 8, 22, 13, 27, 50, 726, DateTimeKind.Local).AddTicks(1503), 8 });

            migrationBuilder.UpdateData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "InsertDate", "RoleId", "UserId" },
                values: new object[] { new DateTime(2025, 8, 22, 13, 27, 50, 726, DateTimeKind.Local).AddTicks(1633), 4, 9 });

            migrationBuilder.UpdateData(
                table: "UserRols",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "InsertDate", "RoleId", "UserId" },
                values: new object[] { new DateTime(2025, 8, 22, 13, 27, 50, 726, DateTimeKind.Local).AddTicks(1760), 2, 10 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertDate", "MobileNumber" },
                values: new object[] { new DateTime(2025, 8, 22, 13, 27, 50, 725, DateTimeKind.Local).AddTicks(5326), "09120000001" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertDate",
                value: new DateTime(2025, 8, 22, 13, 27, 50, 725, DateTimeKind.Local).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertDate",
                value: new DateTime(2025, 8, 22, 13, 27, 50, 725, DateTimeKind.Local).AddTicks(5990));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertDate",
                value: new DateTime(2025, 8, 22, 13, 27, 50, 725, DateTimeKind.Local).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertDate",
                value: new DateTime(2025, 8, 22, 13, 27, 50, 725, DateTimeKind.Local).AddTicks(6609));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "InsertDate",
                value: new DateTime(2025, 8, 22, 13, 27, 50, 725, DateTimeKind.Local).AddTicks(6922));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "InsertDate",
                value: new DateTime(2025, 8, 22, 13, 27, 50, 725, DateTimeKind.Local).AddTicks(7233));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "InsertDate",
                value: new DateTime(2025, 8, 22, 13, 27, 50, 725, DateTimeKind.Local).AddTicks(7541));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "InsertDate",
                value: new DateTime(2025, 8, 22, 13, 27, 50, 725, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "InsertDate",
                value: new DateTime(2025, 8, 22, 13, 27, 50, 725, DateTimeKind.Local).AddTicks(8146));
        }
    }
}
