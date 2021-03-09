using Microsoft.EntityFrameworkCore.Migrations;

namespace HayleesThreads.Migrations
{
    public partial class Float : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ProductPrice",
                table: "Products",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPrice",
                table: "Products",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
