using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pustok_MVC.Migrations
{
    /// <inheritdoc />
    public partial class gfrg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_catagories_CatagoryId",
                table: "books");

            migrationBuilder.AlterColumn<int>(
                name: "CatagoryId",
                table: "books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrime",
                table: "bookImgs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_books_catagories_CatagoryId",
                table: "books",
                column: "CatagoryId",
                principalTable: "catagories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_catagories_CatagoryId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "IsPrime",
                table: "bookImgs");

            migrationBuilder.AlterColumn<int>(
                name: "CatagoryId",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_books_catagories_CatagoryId",
                table: "books",
                column: "CatagoryId",
                principalTable: "catagories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
