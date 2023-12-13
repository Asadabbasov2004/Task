using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dinana_mvc.Migrations
{
    /// <inheritdoc />
    public partial class dgikfgb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Images");
        }
    }
}
