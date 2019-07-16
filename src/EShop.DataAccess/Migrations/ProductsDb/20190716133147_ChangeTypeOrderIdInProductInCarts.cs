using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.DataAccess.Migrations.ProductsDb
{
    public partial class ChangeTypeOrderIdInProductInCarts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInCarts_Orders_OrderId",
                table: "ProductsInCarts");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "ProductsInCarts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInCarts_Orders_OrderId",
                table: "ProductsInCarts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInCarts_Orders_OrderId",
                table: "ProductsInCarts");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "ProductsInCarts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInCarts_Orders_OrderId",
                table: "ProductsInCarts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
