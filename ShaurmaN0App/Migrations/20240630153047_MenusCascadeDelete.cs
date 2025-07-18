using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShaurmaN0App.Migrations
{
    /// <inheritdoc />
    public partial class MenusCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_MenusCategory_MenusCategoryId",
                table: "Menus");

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
                defaultValue: new Guid("ad23a096-fa50-4160-b4fb-834433293008"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("43c639e4-4163-4503-b806-a719b386f8ad"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Menus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f46b24a3-0473-4247-a0a4-402246ae32bf"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("be4155fc-306d-44ae-8c3a-1cfb9ba9ca38"));

            migrationBuilder.InsertData(
                table: "MenusCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("095b8f94-afe1-428b-9852-6596de3b8d5a"), "food" },
                    { new Guid("a1073a67-956a-423e-8fd5-4afb6c5c9795"), "drinkables" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "MenusCategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("480758ac-fcc4-4f29-9f7b-ec53e20778af"), new Guid("a1073a67-956a-423e-8fd5-4afb6c5c9795"), "Cola", 1.5 },
                    { new Guid("ec1abfe7-9344-4b03-8315-2800ce03d2d4"), new Guid("095b8f94-afe1-428b-9852-6596de3b8d5a"), "Shaurma", 5.0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_MenusCategory_MenusCategoryId",
                table: "Menus",
                column: "MenusCategoryId",
                principalTable: "MenusCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_MenusCategory_MenusCategoryId",
                table: "Menus");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("480758ac-fcc4-4f29-9f7b-ec53e20778af"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("ec1abfe7-9344-4b03-8315-2800ce03d2d4"));

            migrationBuilder.DeleteData(
                table: "MenusCategory",
                keyColumn: "Id",
                keyValue: new Guid("095b8f94-afe1-428b-9852-6596de3b8d5a"));

            migrationBuilder.DeleteData(
                table: "MenusCategory",
                keyColumn: "Id",
                keyValue: new Guid("a1073a67-956a-423e-8fd5-4afb6c5c9795"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "MenusCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("43c639e4-4163-4503-b806-a719b386f8ad"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ad23a096-fa50-4160-b4fb-834433293008"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Menus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("be4155fc-306d-44ae-8c3a-1cfb9ba9ca38"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f46b24a3-0473-4247-a0a4-402246ae32bf"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_MenusCategory_MenusCategoryId",
                table: "Menus",
                column: "MenusCategoryId",
                principalTable: "MenusCategory",
                principalColumn: "Id");
        }
    }
}
