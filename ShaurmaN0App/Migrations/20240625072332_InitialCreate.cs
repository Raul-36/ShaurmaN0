using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShaurmaN0App.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenusCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("42e51504-0b8c-4364-8f97-ff3af664febe")),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenusCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("fc8a1dd6-3965-4e85-bc07-8712a4cb12d0")),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenusCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_MenusCategory_MenusCategoryId",
                        column: x => x.MenusCategoryId,
                        principalTable: "MenusCategory",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Menus_MenusCategoryId",
                table: "Menus",
                column: "MenusCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "MenusCategory");
        }
    }
}
