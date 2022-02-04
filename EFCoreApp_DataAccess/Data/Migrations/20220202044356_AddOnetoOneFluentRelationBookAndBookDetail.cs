using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreApp_DataAccess.Data.Migrations
{
    public partial class AddOnetoOneFluentRelationBookAndBookDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookDetailId",
                table: "Fluent_Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Books_BookDetailId",
                table: "Fluent_Books",
                column: "BookDetailId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Fluent_BookDetails_BookDetailId",
                table: "Fluent_Books",
                column: "BookDetailId",
                principalTable: "Fluent_BookDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Fluent_BookDetails_BookDetailId",
                table: "Fluent_Books");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Books_BookDetailId",
                table: "Fluent_Books");

            migrationBuilder.DropColumn(
                name: "BookDetailId",
                table: "Fluent_Books");
        }
    }
}
