using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class update_coffee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81bc4020-6ffd-4c1f-92f4-b3461718dc37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efc2ba77-df1c-4c3b-90b2-66dfaaa723ef");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Coffes",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "path",
                table: "Coffes",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Coffes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Coffes",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreateAt", "Name", "NormalizedName", "UpdateAt" },
                values: new object[,]
                {
                    { "6633638a-a451-49a4-8d3a-4a1fcf4778ea", null, new DateTime(2024, 10, 15, 8, 39, 47, 610, DateTimeKind.Utc).AddTicks(8120), "User", "USER", new DateTime(2024, 10, 15, 8, 39, 47, 610, DateTimeKind.Utc).AddTicks(8120) },
                    { "906a25e4-1a54-4cb9-b9f8-32bf6f2d4e60", null, new DateTime(2024, 10, 15, 8, 39, 47, 593, DateTimeKind.Utc).AddTicks(4470), "Admin", "ADMIN", new DateTime(2024, 10, 15, 8, 39, 47, 610, DateTimeKind.Utc).AddTicks(4180) }
                });

            migrationBuilder.UpdateData(
                table: "CoffeSizes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 15, 8, 39, 47, 610, DateTimeKind.Utc).AddTicks(9390), new DateTime(2024, 10, 15, 8, 39, 47, 610, DateTimeKind.Utc).AddTicks(9390) });

            migrationBuilder.UpdateData(
                table: "CoffeSizes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Percent", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(100), (short)20, new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(110) });

            migrationBuilder.UpdateData(
                table: "CoffeSizes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Percent", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(110), (short)30, new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(110) });

            migrationBuilder.UpdateData(
                table: "Coffes",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(760), new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(760) });

            migrationBuilder.UpdateData(
                table: "Coffes",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(1470), new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(1470) });

            migrationBuilder.UpdateData(
                table: "Coffes",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(1470), new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(1470) });

            migrationBuilder.UpdateData(
                table: "Coffes",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(1480), new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(1480) });

            migrationBuilder.UpdateData(
                table: "Coffes",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(1480), new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(1480) });

            migrationBuilder.UpdateData(
                table: "Coffes",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(1490), new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(1490) });

            migrationBuilder.UpdateData(
                table: "Coffes",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(1490), new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(1490) });

            migrationBuilder.UpdateData(
                table: "Coffes",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(1490), new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(1490) });

            migrationBuilder.UpdateData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(2150), new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(2150) });

            migrationBuilder.UpdateData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(2650), new DateTime(2024, 10, 15, 8, 39, 47, 611, DateTimeKind.Utc).AddTicks(2660) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6633638a-a451-49a4-8d3a-4a1fcf4778ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "906a25e4-1a54-4cb9-b9f8-32bf6f2d4e60");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Coffes",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Coffes",
                newName: "path");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Coffes",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Coffes",
                newName: "id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreateAt", "Name", "NormalizedName", "UpdateAt" },
                values: new object[,]
                {
                    { "81bc4020-6ffd-4c1f-92f4-b3461718dc37", null, new DateTime(2024, 10, 13, 22, 39, 24, 892, DateTimeKind.Utc).AddTicks(6370), "Admin", "ADMIN", new DateTime(2024, 10, 13, 22, 39, 24, 909, DateTimeKind.Utc).AddTicks(5970) },
                    { "efc2ba77-df1c-4c3b-90b2-66dfaaa723ef", null, new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(120), "User", "USER", new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(130) }
                });

            migrationBuilder.UpdateData(
                table: "CoffeSizes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(1560), new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(1560) });

            migrationBuilder.UpdateData(
                table: "CoffeSizes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Percent", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(2150), (short)0, new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(2150) });

            migrationBuilder.UpdateData(
                table: "CoffeSizes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Percent", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(2150), (short)0, new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(2160) });

            migrationBuilder.UpdateData(
                table: "Coffes",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(2830), new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(2840) });

            migrationBuilder.UpdateData(
                table: "Coffes",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3610), new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3610) });

            migrationBuilder.UpdateData(
                table: "Coffes",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3620), new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3620) });

            migrationBuilder.UpdateData(
                table: "Coffes",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3620), new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3620) });

            migrationBuilder.UpdateData(
                table: "Coffes",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3620), new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3630) });

            migrationBuilder.UpdateData(
                table: "Coffes",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3660), new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3660) });

            migrationBuilder.UpdateData(
                table: "Coffes",
                keyColumn: "id",
                keyValue: 7L,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3670), new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "Coffes",
                keyColumn: "id",
                keyValue: 8L,
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3670), new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(4360), new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(4370) });

            migrationBuilder.UpdateData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(4910), new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(4910) });
        }
    }
}
