using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShaurmaN0App.Migrations
{
    /// <inheritdoc />
    public partial class UniqueNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MenusCategory",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "MenusCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("3069e09f-ca72-4726-a589-0ac917b5d4cc"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ad23a096-fa50-4160-b4fb-834433293008"));

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Menus",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Menus",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Menus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("97c81f96-5fe9-402d-965e-8a948702a851"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f46b24a3-0473-4247-a0a4-402246ae32bf"));

            migrationBuilder.InsertData(
                table: "MenusCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1c2edb52-859b-43dc-8195-1078a72fa35f"), "drinkables" },
                    { new Guid("ba8560ae-88cb-4f03-b7df-a5574ccdbe56"), "food" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "MenusCategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("146851d6-3158-4be1-ac7d-da077f8703cc"), new Guid("ba8560ae-88cb-4f03-b7df-a5574ccdbe56"), "Shaurma", 5.0 },
                    { new Guid("2f18e7e0-5aec-4910-9fa6-7b385e4e2c79"), new Guid("1c2edb52-859b-43dc-8195-1078a72fa35f"), "Cola", 1.5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenusCategory_Name",
                table: "MenusCategory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Name",
                table: "Menus",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MenusCategory_Name",
                table: "MenusCategory");

            migrationBuilder.DropIndex(
                name: "IX_Menus_Name",
                table: "Menus");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("146851d6-3158-4be1-ac7d-da077f8703cc"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("2f18e7e0-5aec-4910-9fa6-7b385e4e2c79"));

            migrationBuilder.DeleteData(
                table: "MenusCategory",
                keyColumn: "Id",
                keyValue: new Guid("1c2edb52-859b-43dc-8195-1078a72fa35f"));

            migrationBuilder.DeleteData(
                table: "MenusCategory",
                keyColumn: "Id",
                keyValue: new Guid("ba8560ae-88cb-4f03-b7df-a5574ccdbe56"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MenusCategory",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "MenusCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ad23a096-fa50-4160-b4fb-834433293008"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("3069e09f-ca72-4726-a589-0ac917b5d4cc"));

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Menus",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Menus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f46b24a3-0473-4247-a0a4-402246ae32bf"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("97c81f96-5fe9-402d-965e-8a948702a851"));

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
        }
    }
}
