using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShaurmaN0App.Migrations
{
    /// <inheritdoc />
    public partial class InitOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "MenusCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("83ce475a-ee39-47e8-a7bd-074e224fe17d"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("976e227e-2c96-4f75-a76e-dd64f1027472"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Menus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("36aabd50-6455-4d47-9827-b65e60e29d6f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9c46a451-c473-49da-acfb-9adaafffa60a"));

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MenusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Coutn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Menus_MenusId",
                        column: x => x.MenusId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenusId",
                table: "OrderItems",
                column: "MenusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "MenusCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("976e227e-2c96-4f75-a76e-dd64f1027472"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("83ce475a-ee39-47e8-a7bd-074e224fe17d"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Menus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9c46a451-c473-49da-acfb-9adaafffa60a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("36aabd50-6455-4d47-9827-b65e60e29d6f"));
        }
    }
}
