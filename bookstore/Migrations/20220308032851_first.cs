using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookstore.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategories_Books_BookId",
                table: "BookCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCategories_Categories_CategoryId",
                table: "BookCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCategories",
                table: "BookCategories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "category");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "book");

            migrationBuilder.RenameTable(
                name: "BookCategories",
                newName: "category_book");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "category",
                newName: "category_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "category",
                newName: "category_id");

            migrationBuilder.RenameColumn(
                name: "storedCopies",
                table: "book",
                newName: "stored_copies");

            migrationBuilder.RenameColumn(
                name: "currentRent",
                table: "book",
                newName: "current_rent");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "book",
                newName: "book_title");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "book",
                newName: "book_id");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "category_book",
                newName: "book_id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "category_book",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategories_BookId",
                table: "category_book",
                newName: "IX_category_book_book_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category",
                table: "category",
                column: "category_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_book",
                table: "book",
                column: "book_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category_book",
                table: "category_book",
                columns: new[] { "category_id", "book_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_category_book_book_book_id",
                table: "category_book",
                column: "book_id",
                principalTable: "book",
                principalColumn: "book_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_category_book_category_category_id",
                table: "category_book",
                column: "category_id",
                principalTable: "category",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_book_book_book_id",
                table: "category_book");

            migrationBuilder.DropForeignKey(
                name: "FK_category_book_category_category_id",
                table: "category_book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category_book",
                table: "category_book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category",
                table: "category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_book",
                table: "book");

            migrationBuilder.RenameTable(
                name: "category_book",
                newName: "BookCategories");

            migrationBuilder.RenameTable(
                name: "category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "book",
                newName: "Books");

            migrationBuilder.RenameColumn(
                name: "book_id",
                table: "BookCategories",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "BookCategories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_category_book_book_id",
                table: "BookCategories",
                newName: "IX_BookCategories_BookId");

            migrationBuilder.RenameColumn(
                name: "category_name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "stored_copies",
                table: "Books",
                newName: "storedCopies");

            migrationBuilder.RenameColumn(
                name: "current_rent",
                table: "Books",
                newName: "currentRent");

            migrationBuilder.RenameColumn(
                name: "book_title",
                table: "Books",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "book_id",
                table: "Books",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCategories",
                table: "BookCategories",
                columns: new[] { "CategoryId", "BookId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategories_Books_BookId",
                table: "BookCategories",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategories_Categories_CategoryId",
                table: "BookCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
