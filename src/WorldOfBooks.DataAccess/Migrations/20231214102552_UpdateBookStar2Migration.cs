using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldOfBooks.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookStar2Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvverageStars",
                table: "BookStars",
                newName: "AverageStars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AverageStars",
                table: "BookStars",
                newName: "AvverageStars");
        }
    }
}
