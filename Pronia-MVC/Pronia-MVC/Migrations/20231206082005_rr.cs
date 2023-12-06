using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pronia_MVC.Migrations
{
    /// <inheritdoc />
    public partial class rr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrime",
                table: "Products");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrime",
                table: "Products",
                type: "bit",
                nullable: true);
        }
    }
}
