using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceSite.Migrations
{
    public partial class addedidforproductstoShopCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ShopCustomers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShopCustomerId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShopCustomerId",
                table: "Products",
                column: "ShopCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShopCustomers_ShopCustomerId",
                table: "Products",
                column: "ShopCustomerId",
                principalTable: "ShopCustomers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShopCustomers_ShopCustomerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShopCustomerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ShopCustomers");

            migrationBuilder.DropColumn(
                name: "ShopCustomerId",
                table: "Products");
        }
    }
}
