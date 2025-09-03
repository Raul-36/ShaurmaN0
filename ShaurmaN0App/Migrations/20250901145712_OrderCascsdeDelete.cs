using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShaurmaN0App.Migrations
{
    /// <inheritdoc />
    public partial class OrderCascsdeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Menus_MenusId",
                table: "OrderItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "MenusCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("012d3dea-2b66-4afb-8205-53dc6af263e8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("830e2841-8f89-4132-8e6f-ab40c00554d4"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Menus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("61b2ada2-c2dc-44da-a068-10e3c2386861"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("cdf9fb64-7e63-4c4c-bcfc-26b543ac6c01"));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Menus_MenusId",
                table: "OrderItems",
                column: "MenusId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Menus_MenusId",
                table: "OrderItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "MenusCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("830e2841-8f89-4132-8e6f-ab40c00554d4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("012d3dea-2b66-4afb-8205-53dc6af263e8"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Menus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("cdf9fb64-7e63-4c4c-bcfc-26b543ac6c01"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("61b2ada2-c2dc-44da-a068-10e3c2386861"));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Menus_MenusId",
                table: "OrderItems",
                column: "MenusId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
