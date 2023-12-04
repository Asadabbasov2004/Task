using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pronia_MVC.Migrations
{
    /// <inheritdoc />
    public partial class asasas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrime",
                table: "Products",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrime",
                table: "Products");
        }
    }
}
