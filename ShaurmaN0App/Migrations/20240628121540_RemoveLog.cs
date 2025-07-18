using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShaurmaN0App.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("03e7b790-2ae3-414c-aea6-643e9793a71a"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("a8a4edbd-81aa-4cfe-9a41-d2a703c5e62c"));

            migrationBuilder.DeleteData(
                table: "MenusCategory",
                keyColumn: "Id",
                keyValue: new Guid("e1ab5cd2-dbd3-44d3-a2e4-e9fe1df81554"));

            migrationBuilder.DeleteData(
                table: "MenusCategory",
                keyColumn: "Id",
                keyValue: new Guid("e590882f-369a-45f9-958f-091a091dca95"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "MenusCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("43c639e4-4163-4503-b806-a719b386f8ad"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2cdc1889-d6a2-4dc8-8173-0f0c4100871a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Menus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("be4155fc-306d-44ae-8c3a-1cfb9ba9ca38"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("51c9814f-e5ec-4985-8a90-88dc37af5423"));

            migrationBuilder.InsertData(
                table: "MenusCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("03601bd2-66af-4290-9506-efee2374bba1"), "drinkables" },
                    { new Guid("d9f1bf75-5296-4a41-8357-d1121136a3f5"), "food" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "MenusCategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("2f643f32-2aa7-47e6-ac1e-ea97ab2f03c8"), new Guid("03601bd2-66af-4290-9506-efee2374bba1"), "Cola", 1.5 },
                    { new Guid("ae14d479-5ce8-4ec1-ae4c-d233dacab0c4"), new Guid("d9f1bf75-5296-4a41-8357-d1121136a3f5"), "Shaurma", 5.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("2f643f32-2aa7-47e6-ac1e-ea97ab2f03c8"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("ae14d479-5ce8-4ec1-ae4c-d233dacab0c4"));

            migrationBuilder.DeleteData(
                table: "MenusCategory",
                keyColumn: "Id",
                keyValue: new Guid("03601bd2-66af-4290-9506-efee2374bba1"));

            migrationBuilder.DeleteData(
                table: "MenusCategory",
                keyColumn: "Id",
                keyValue: new Guid("d9f1bf75-5296-4a41-8357-d1121136a3f5"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "MenusCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2cdc1889-d6a2-4dc8-8173-0f0c4100871a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("43c639e4-4163-4503-b806-a719b386f8ad"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Menus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("51c9814f-e5ec-4985-8a90-88dc37af5423"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("be4155fc-306d-44ae-8c3a-1cfb9ba9ca38"));

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HttpMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponseBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusCode = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MenusCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("e1ab5cd2-dbd3-44d3-a2e4-e9fe1df81554"), "food" },
                    { new Guid("e590882f-369a-45f9-958f-091a091dca95"), "drinkables" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "MenusCategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("03e7b790-2ae3-414c-aea6-643e9793a71a"), new Guid("e1ab5cd2-dbd3-44d3-a2e4-e9fe1df81554"), "Shaurma", 5.0 },
                    { new Guid("a8a4edbd-81aa-4cfe-9a41-d2a703c5e62c"), new Guid("e590882f-369a-45f9-958f-091a091dca95"), "Cola", 1.5 }
                });
        }
    }
}
