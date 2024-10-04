using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CoffeSizes",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createAt", "updateAt" },
                values: new object[] { new DateTime(2024, 10, 4, 16, 9, 26, 891, DateTimeKind.Utc).AddTicks(4794), new DateTime(2024, 10, 4, 16, 9, 26, 891, DateTimeKind.Utc).AddTicks(4795) });

            migrationBuilder.UpdateData(
                table: "CoffeSizes",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createAt", "updateAt" },
                values: new object[] { new DateTime(2024, 10, 4, 16, 9, 26, 891, DateTimeKind.Utc).AddTicks(5079), new DateTime(2024, 10, 4, 16, 9, 26, 891, DateTimeKind.Utc).AddTicks(5080) });

            migrationBuilder.UpdateData(
                table: "CoffeSizes",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createAt", "updateAt" },
                values: new object[] { new DateTime(2024, 10, 4, 16, 9, 26, 891, DateTimeKind.Utc).AddTicks(5081), new DateTime(2024, 10, 4, 16, 9, 26, 891, DateTimeKind.Utc).AddTicks(5081) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreateAt", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 4, 16, 9, 26, 890, DateTimeKind.Utc).AddTicks(2303), "ADMIN", new DateTime(2024, 10, 4, 16, 9, 26, 891, DateTimeKind.Utc).AddTicks(3766) },
                    { 2, new DateTime(2024, 10, 4, 16, 9, 26, 891, DateTimeKind.Utc).AddTicks(4319), "USER", new DateTime(2024, 10, 4, 16, 9, 26, 891, DateTimeKind.Utc).AddTicks(4321) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "CoffeSizes",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createAt", "updateAt" },
                values: new object[] { new DateTime(2024, 10, 4, 16, 5, 48, 907, DateTimeKind.Utc).AddTicks(2159), new DateTime(2024, 10, 4, 16, 5, 48, 907, DateTimeKind.Utc).AddTicks(2160) });

            migrationBuilder.UpdateData(
                table: "CoffeSizes",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createAt", "updateAt" },
                values: new object[] { new DateTime(2024, 10, 4, 16, 5, 48, 907, DateTimeKind.Utc).AddTicks(2454), new DateTime(2024, 10, 4, 16, 5, 48, 907, DateTimeKind.Utc).AddTicks(2455) });

            migrationBuilder.UpdateData(
                table: "CoffeSizes",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createAt", "updateAt" },
                values: new object[] { new DateTime(2024, 10, 4, 16, 5, 48, 907, DateTimeKind.Utc).AddTicks(2456), new DateTime(2024, 10, 4, 16, 5, 48, 907, DateTimeKind.Utc).AddTicks(2456) });
        }
    }
}
