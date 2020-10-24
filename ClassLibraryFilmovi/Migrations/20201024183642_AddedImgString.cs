using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibraryFilmovi.Migrations
{
    public partial class AddedImgString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "Film",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img",
                table: "Film");
        }
    }
}
