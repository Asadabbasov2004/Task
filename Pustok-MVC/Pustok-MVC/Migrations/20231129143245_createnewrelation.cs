using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pustok_MVC.Migrations
{
    /// <inheritdoc />
    public partial class createnewrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTags_books_BookId",
                table: "BookTags");

            migrationBuilder.DropForeignKey(
                name: "FK_BookTags_tags_TagId",
                table: "BookTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookTags",
                table: "BookTags");

            migrationBuilder.RenameTable(
                name: "BookTags",
                newName: "bookTags");

            migrationBuilder.RenameIndex(
                name: "IX_BookTags_TagId",
                table: "bookTags",
                newName: "IX_bookTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_BookTags_BookId",
                table: "bookTags",
                newName: "IX_bookTags_BookId");

            migrationBuilder.AddColumn<int>(
                name: "CatagoryId",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CatagoryId",
                table: "blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookTags",
                table: "bookTags",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "blogImgs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogImgs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blogImgs_blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "blogsTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogsTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blogsTag_blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_blogsTag_tags_TagId",
                        column: x => x.TagId,
                        principalTable: "tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_CatagoryId",
                table: "books",
                column: "CatagoryId");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_CatagoryId",
                table: "blogs",
                column: "CatagoryId");

            migrationBuilder.CreateIndex(
                name: "IX_blogImgs_BlogId",
                table: "blogImgs",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_blogsTag_BlogId",
                table: "blogsTag",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_blogsTag_TagId",
                table: "blogsTag",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_catagories_CatagoryId",
                table: "blogs",
                column: "CatagoryId",
                principalTable: "catagories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_books_catagories_CatagoryId",
                table: "books",
                column: "CatagoryId",
                principalTable: "catagories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookTags_books_BookId",
                table: "bookTags",
                column: "BookId",
                principalTable: "books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookTags_tags_TagId",
                table: "bookTags",
                column: "TagId",
                principalTable: "tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_catagories_CatagoryId",
                table: "blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_books_catagories_CatagoryId",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_bookTags_books_BookId",
                table: "bookTags");

            migrationBuilder.DropForeignKey(
                name: "FK_bookTags_tags_TagId",
                table: "bookTags");

            migrationBuilder.DropTable(
                name: "blogImgs");

            migrationBuilder.DropTable(
                name: "blogsTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookTags",
                table: "bookTags");

            migrationBuilder.DropIndex(
                name: "IX_books_CatagoryId",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_blogs_CatagoryId",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "CatagoryId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "CatagoryId",
                table: "blogs");

            migrationBuilder.RenameTable(
                name: "bookTags",
                newName: "BookTags");

            migrationBuilder.RenameIndex(
                name: "IX_bookTags_TagId",
                table: "BookTags",
                newName: "IX_BookTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_bookTags_BookId",
                table: "BookTags",
                newName: "IX_BookTags_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookTags",
                table: "BookTags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTags_books_BookId",
                table: "BookTags",
                column: "BookId",
                principalTable: "books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookTags_tags_TagId",
                table: "BookTags",
                column: "TagId",
                principalTable: "tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
