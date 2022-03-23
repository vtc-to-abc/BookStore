using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookstore.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    author_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pseudonym = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.author_id);
                });

            migrationBuilder.CreateTable(
                name: "renter",
                columns: table => new
                {
                    renter_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    renter_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    renter_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    renter_email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_renter", x => x.renter_id);
                });

            migrationBuilder.CreateTable(
                name: "author_book",
                columns: table => new
                {
                    author_id = table.Column<int>(type: "int", nullable: false),
                    book_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author_book", x => new { x.author_id, x.book_id });
                    table.ForeignKey(
                        name: "FK_author_book_author_author_id",
                        column: x => x.author_id,
                        principalTable: "author",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_author_book_book_book_id",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rentorder",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    renter_id = table.Column<int>(type: "int", nullable: false),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    rent_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    return_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rent_status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rentorder", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_rentorder_book_book_id",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rentorder_renter_renter_id",
                        column: x => x.renter_id,
                        principalTable: "renter",
                        principalColumn: "renter_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_author_book_book_id",
                table: "author_book",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_rentorder_book_id",
                table: "rentorder",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_rentorder_renter_id",
                table: "rentorder",
                column: "renter_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "author_book");

            migrationBuilder.DropTable(
                name: "rentorder");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "renter");
        }
    }
}
