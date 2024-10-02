using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coffes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CoffeSizes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    createAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeSizes", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "CoffeSizes",
                columns: new[] { "id", "createAt", "name", "updateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 2, 9, 18, 31, 980, DateTimeKind.Utc).AddTicks(7050), "S", new DateTime(2024, 10, 2, 9, 18, 31, 997, DateTimeKind.Utc).AddTicks(2620) },
                    { 2, new DateTime(2024, 10, 2, 9, 18, 31, 997, DateTimeKind.Utc).AddTicks(3350), "M", new DateTime(2024, 10, 2, 9, 18, 31, 997, DateTimeKind.Utc).AddTicks(3350) },
                    { 3, new DateTime(2024, 10, 2, 9, 18, 31, 997, DateTimeKind.Utc).AddTicks(3350), "L", new DateTime(2024, 10, 2, 9, 18, 31, 997, DateTimeKind.Utc).AddTicks(3350) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coffes");

            migrationBuilder.DropTable(
                name: "CoffeSizes");
        }
    }
}
