using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HayleesThreads.Migrations
{
    public partial class Remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartProduct_Products_ProductId",
                table: "ShoppingCartProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartProduct_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartProduct");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartProduct",
                table: "ShoppingCartProduct");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartProduct_ShoppingCartId",
                table: "ShoppingCartProduct");

            migrationBuilder.RenameTable(
                name: "ShoppingCartProduct",
                newName: "ShoppingCartProducts");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartProduct_ProductId",
                table: "ShoppingCartProducts",
                newName: "IX_ShoppingCartProducts_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "ShoppingCartId",
                table: "ShoppingCartProducts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartProducts",
                table: "ShoppingCartProducts",
                column: "ShoppingCartProductId");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(maxLength: 2, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 5, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ProductPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartProducts_Products_ProductId",
                table: "ShoppingCartProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartProducts_Products_ProductId",
                table: "ShoppingCartProducts");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartProducts",
                table: "ShoppingCartProducts");

            migrationBuilder.RenameTable(
                name: "ShoppingCartProducts",
                newName: "ShoppingCartProduct");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartProducts_ProductId",
                table: "ShoppingCartProduct",
                newName: "IX_ShoppingCartProduct_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "ShoppingCartId",
                table: "ShoppingCartProduct",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartProduct",
                table: "ShoppingCartProduct",
                column: "ShoppingCartProductId");

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    ShoppingCartId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.ShoppingCartId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartProduct_ShoppingCartId",
                table: "ShoppingCartProduct",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartProduct_Products_ProductId",
                table: "ShoppingCartProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartProduct_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartProduct",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "ShoppingCartId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
