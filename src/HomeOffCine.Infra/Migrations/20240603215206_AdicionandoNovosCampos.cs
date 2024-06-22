using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeOffCine.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoNovosCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageBanner",
                table: "Movies",
                type: "varchar(1000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlTrailer",
                table: "Movies",
                type: "varchar(1000)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageBanner",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "UrlTrailer",
                table: "Movies");
        }
    }
}
