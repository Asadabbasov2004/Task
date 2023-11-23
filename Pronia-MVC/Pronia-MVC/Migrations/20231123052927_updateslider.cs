using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pronia_MVC.Migrations
{
    /// <inheritdoc />
    public partial class updateslider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productTags_tags_TagId",
                table: "productTags");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "productTags",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_productTags_tags_TagId",
                table: "productTags",
                column: "TagId",
                principalTable: "tags",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productTags_tags_TagId",
                table: "productTags");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "productTags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_productTags_tags_TagId",
                table: "productTags",
                column: "TagId",
                principalTable: "tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
