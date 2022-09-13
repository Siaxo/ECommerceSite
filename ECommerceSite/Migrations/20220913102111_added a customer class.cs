using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceSite.Migrations
{
    public partial class addedacustomerclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShopCustomerId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ShopCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCustomers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ShopCustomerId",
                table: "Carts",
                column: "ShopCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_ShopCustomers_ShopCustomerId",
                table: "Carts",
                column: "ShopCustomerId",
                principalTable: "ShopCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_ShopCustomers_ShopCustomerId",
                table: "Carts");

            migrationBuilder.DropTable(
                name: "ShopCustomers");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ShopCustomerId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ShopCustomerId",
                table: "Carts");
        }
    }
}
