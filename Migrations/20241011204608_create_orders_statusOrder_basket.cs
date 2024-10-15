using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class create_orders_statusOrder_basket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d0edbcd-1419-4a0b-aaad-54d1acc8bef3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99c7e5d1-2707-4f3f-a634-0af7800ca7fc");

            migrationBuilder.CreateTable(
                name: "StatusOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    StatusOrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_StatusOrders_StatusOrderId",
                        column: x => x.StatusOrderId,
                        principalTable: "StatusOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CountSugar = table.Column<short>(type: "smallint", nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrderId = table.Column<string>(type: "text", nullable: false),
                    CoffeeSizeId = table.Column<int>(type: "integer", nullable: false),
                    CoffeeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_CoffeSizes_CoffeeSizeId",
                        column: x => x.CoffeeSizeId,
                        principalTable: "CoffeSizes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Baskets_Coffes_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Baskets_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_CoffeeId",
                table: "Baskets",
                column: "CoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_CoffeeSizeId",
                table: "Baskets",
                column: "CoffeeSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_OrderId",
                table: "Baskets",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusOrderId",
                table: "Orders",
                column: "StatusOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "StatusOrders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6c06766-3692-43fe-857f-37f7c5fb66cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0f85118-5609-425b-8a0f-9419ae1b40c0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreateAt", "Name", "NormalizedName", "UpdateAt" },
                values: new object[,]
                {
                    { "4d0edbcd-1419-4a0b-aaad-54d1acc8bef3", null, new DateTime(2024, 10, 10, 14, 13, 41, 192, DateTimeKind.Utc).AddTicks(2040), "Admin", "ADMIN", new DateTime(2024, 10, 10, 14, 13, 41, 205, DateTimeKind.Utc).AddTicks(570) },
                    { "99c7e5d1-2707-4f3f-a634-0af7800ca7fc", null, new DateTime(2024, 10, 10, 14, 13, 41, 205, DateTimeKind.Utc).AddTicks(3690), "User", "USER", new DateTime(2024, 10, 10, 14, 13, 41, 205, DateTimeKind.Utc).AddTicks(3690) }
                });

            migrationBuilder.UpdateData(
                table: "CoffeSizes",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createAt", "updateAt" },
                values: new object[] { new DateTime(2024, 10, 10, 14, 13, 41, 205, DateTimeKind.Utc).AddTicks(4350), new DateTime(2024, 10, 10, 14, 13, 41, 205, DateTimeKind.Utc).AddTicks(4350) });

            migrationBuilder.UpdateData(
                table: "CoffeSizes",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createAt", "updateAt" },
                values: new object[] { new DateTime(2024, 10, 10, 14, 13, 41, 205, DateTimeKind.Utc).AddTicks(4740), new DateTime(2024, 10, 10, 14, 13, 41, 205, DateTimeKind.Utc).AddTicks(4750) });

            migrationBuilder.UpdateData(
                table: "CoffeSizes",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createAt", "updateAt" },
                values: new object[] { new DateTime(2024, 10, 10, 14, 13, 41, 205, DateTimeKind.Utc).AddTicks(4750), new DateTime(2024, 10, 10, 14, 13, 41, 205, DateTimeKind.Utc).AddTicks(4750) });
        }
    }
}
