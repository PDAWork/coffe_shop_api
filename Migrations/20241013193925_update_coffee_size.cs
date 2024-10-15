using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class update_coffee_size : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6c06766-3692-43fe-857f-37f7c5fb66cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0f85118-5609-425b-8a0f-9419ae1b40c0");

            migrationBuilder.RenameColumn(
                name: "updateAt",
                table: "CoffeSizes",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "CoffeSizes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "createAt",
                table: "CoffeSizes",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CoffeSizes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updateAt",
                table: "Coffes",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "createAt",
                table: "Coffes",
                newName: "CreateAt");

            migrationBuilder.AddColumn<short>(
                name: "Percent",
                table: "CoffeSizes",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

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
                columns: new[] { "CreateAt", "Percent", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(1560), (short)0, new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(1560) });

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

            migrationBuilder.InsertData(
                table: "Coffes",
                columns: new[] { "id", "CreateAt", "UpdateAt", "name", "path", "price" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(2830), new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(2840), "Американо", "85539d89-23ab-41bc-9267-0f86e35957f4.svg", 275f },
                    { 2L, new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3610), new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3610), "Латте", "5d5dc247-eba6-44d4-a87d-24475f7f40bf.svg", 330f },
                    { 3L, new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3620), new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3620), "Эспрессо", "635a7237-552b-459c-a304-6c32e6ba29fa.svg", 150f },
                    { 4L, new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3620), new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3620), "Макиато", "5779c99f-1228-42e7-ad32-b447d3f750a2.svg", 365f },
                    { 5L, new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3620), new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3630), "Лунго", "e80b89f0-09c2-4f31-85e7-c1ab61cb4cab.svg", 350f },
                    { 6L, new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3660), new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3660), "Корретто", "9760acfa-75a3-4b2a-b599-c6dc811c939c.svg", 365f },
                    { 7L, new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3670), new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3670), "Эспрессо Романо", "e0f2d3d9-17fc-4c90-bf76-49fa22d059e2.svg", 200f },
                    { 8L, new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3670), new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(3670), "Галан", "b3355c87-de26-4c93-9673-dd725ea7757c.svg", 330f }
                });

            migrationBuilder.InsertData(
                table: "StatusOrders",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(4360), "Pending", new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(4370) },
                    { 2, new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(4910), "Confirmed", new DateTime(2024, 10, 13, 22, 39, 24, 910, DateTimeKind.Utc).AddTicks(4910) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81bc4020-6ffd-4c1f-92f4-b3461718dc37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efc2ba77-df1c-4c3b-90b2-66dfaaa723ef");

            migrationBuilder.DeleteData(
                table: "Coffes",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Coffes",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Coffes",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Coffes",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Coffes",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Coffes",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Coffes",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Coffes",
                keyColumn: "id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Percent",
                table: "CoffeSizes");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "CoffeSizes",
                newName: "updateAt");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CoffeSizes",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "CoffeSizes",
                newName: "createAt");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CoffeSizes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Coffes",
                newName: "updateAt");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Coffes",
                newName: "createAt");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreateAt", "Name", "NormalizedName", "UpdateAt" },
                values: new object[,]
                {
                    { "a6c06766-3692-43fe-857f-37f7c5fb66cd", null, new DateTime(2024, 10, 11, 23, 46, 8, 52, DateTimeKind.Utc).AddTicks(6320), "User", "USER", new DateTime(2024, 10, 11, 23, 46, 8, 52, DateTimeKind.Utc).AddTicks(6320) },
                    { "b0f85118-5609-425b-8a0f-9419ae1b40c0", null, new DateTime(2024, 10, 11, 23, 46, 8, 35, DateTimeKind.Utc).AddTicks(5210), "Admin", "ADMIN", new DateTime(2024, 10, 11, 23, 46, 8, 52, DateTimeKind.Utc).AddTicks(2390) }
                });

            migrationBuilder.UpdateData(
                table: "CoffeSizes",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createAt", "updateAt" },
                values: new object[] { new DateTime(2024, 10, 11, 23, 46, 8, 52, DateTimeKind.Utc).AddTicks(7470), new DateTime(2024, 10, 11, 23, 46, 8, 52, DateTimeKind.Utc).AddTicks(7470) });

            migrationBuilder.UpdateData(
                table: "CoffeSizes",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createAt", "updateAt" },
                values: new object[] { new DateTime(2024, 10, 11, 23, 46, 8, 52, DateTimeKind.Utc).AddTicks(7980), new DateTime(2024, 10, 11, 23, 46, 8, 52, DateTimeKind.Utc).AddTicks(7980) });

            migrationBuilder.UpdateData(
                table: "CoffeSizes",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createAt", "updateAt" },
                values: new object[] { new DateTime(2024, 10, 11, 23, 46, 8, 52, DateTimeKind.Utc).AddTicks(7980), new DateTime(2024, 10, 11, 23, 46, 8, 52, DateTimeKind.Utc).AddTicks(7990) });
        }
    }
}
