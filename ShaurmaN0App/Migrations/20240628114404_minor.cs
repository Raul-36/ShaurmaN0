using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShaurmaN0App.Migrations
{
    /// <inheritdoc />
    public partial class minor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("ddf08b52-554b-4a09-a506-bba06530d019"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("e2063479-b45d-4383-8b08-89f39de3939d"));

            migrationBuilder.DeleteData(
                table: "MenusCategory",
                keyColumn: "Id",
                keyValue: new Guid("14407acd-1405-4683-a9d1-111214c38179"));

            migrationBuilder.DeleteData(
                table: "MenusCategory",
                keyColumn: "Id",
                keyValue: new Guid("a7beddaf-f163-45ec-b5fb-24c3990b0692"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "MenusCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2cdc1889-d6a2-4dc8-8173-0f0c4100871a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("42e51504-0b8c-4364-8f97-ff3af664febe"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Menus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("51c9814f-e5ec-4985-8a90-88dc37af5423"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("fc8a1dd6-3965-4e85-bc07-8712a4cb12d0"));

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponseBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusCode = table.Column<int>(type: "int", nullable: false),
                    HttpMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new Guid("42e51504-0b8c-4364-8f97-ff3af664febe"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2cdc1889-d6a2-4dc8-8173-0f0c4100871a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Menus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("fc8a1dd6-3965-4e85-bc07-8712a4cb12d0"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("51c9814f-e5ec-4985-8a90-88dc37af5423"));

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "MenusCategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("ddf08b52-554b-4a09-a506-bba06530d019"), null, "Shaurma", 5.0 },
                    { new Guid("e2063479-b45d-4383-8b08-89f39de3939d"), null, "Cola", 1.5 }
                });

            migrationBuilder.InsertData(
                table: "MenusCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("14407acd-1405-4683-a9d1-111214c38179"), "dessert" },
                    { new Guid("a7beddaf-f163-45ec-b5fb-24c3990b0692"), "drinkables" }
                });
        }
    }
}
