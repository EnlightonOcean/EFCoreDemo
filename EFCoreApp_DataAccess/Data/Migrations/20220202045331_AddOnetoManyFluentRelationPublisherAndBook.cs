using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreApp_DataAccess.Data.Migrations
{
    public partial class AddOnetoManyFluentRelationPublisherAndBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Fluent_Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Books_PublisherId",
                table: "Fluent_Books",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Fluent_Publishers_PublisherId",
                table: "Fluent_Books",
                column: "PublisherId",
                principalTable: "Fluent_Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Fluent_Publishers_PublisherId",
                table: "Fluent_Books");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Books_PublisherId",
                table: "Fluent_Books");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Fluent_Books");
        }
    }
}
