using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.DataAccess.Migrations.ProductsDb
{
    public partial class FixUsersKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ShopUser_ShopUserId1",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ShopUserId1",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ShopUserId1",
                table: "Reviews");

            migrationBuilder.AlterColumn<string>(
                name: "ShopUserId",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductsInCarts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShopUserId = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsInCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsInCarts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsInCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsInCarts_ShopUser_ShopUserId",
                        column: x => x.ShopUserId,
                        principalTable: "ShopUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ShopUserId",
                table: "Reviews",
                column: "ShopUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInCarts_OrderId",
                table: "ProductsInCarts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInCarts_ProductId",
                table: "ProductsInCarts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInCarts_ShopUserId",
                table: "ProductsInCarts",
                column: "ShopUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ShopUser_ShopUserId",
                table: "Reviews",
                column: "ShopUserId",
                principalTable: "ShopUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ShopUser_ShopUserId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "ProductsInCarts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ShopUserId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "ShopUserId",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShopUserId1",
                table: "Reviews",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ShopUserId1",
                table: "Reviews",
                column: "ShopUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ShopUser_ShopUserId1",
                table: "Reviews",
                column: "ShopUserId1",
                principalTable: "ShopUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
