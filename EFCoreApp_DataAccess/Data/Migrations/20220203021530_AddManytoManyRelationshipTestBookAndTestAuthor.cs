using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreApp_DataAccess.Data.Migrations
{
    public partial class AddManytoManyRelationshipTestBookAndTestAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAuthors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestAuthorTestBook",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    BooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAuthorTestBook", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_TestAuthorTestBook_TestAuthors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "TestAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestAuthorTestBook_TestBooks_BooksId",
                        column: x => x.BooksId,
                        principalTable: "TestBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestAuthorTestBook_BooksId",
                table: "TestAuthorTestBook",
                column: "BooksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestAuthorTestBook");

            migrationBuilder.DropTable(
                name: "TestAuthors");

            migrationBuilder.DropTable(
                name: "TestBooks");
        }
    }
}
