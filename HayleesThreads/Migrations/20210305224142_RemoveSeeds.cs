using Microsoft.EntityFrameworkCore.Migrations;

namespace HayleesThreads.Migrations
{
    public partial class RemoveSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "AllEars", "CategoryId", "Featured", "ProductDescription", "ProductImage", "ProductName", "ProductPrice", "UserId" },
                values: new object[] { 1, false, 1, true, "Embroided 'Tree of Life'", "\\img\\appa.jpg", "Tree of Life", 14.99m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "AllEars", "CategoryId", "Featured", "ProductDescription", "ProductImage", "ProductName", "ProductPrice", "UserId" },
                values: new object[] { 2, true, 2, true, "Hand-Embroided 'Appa' from Avatar: The Last Airbender", "\\img\\appa.jpg", "Appa", 12.99m, null });
        }
    }
}
