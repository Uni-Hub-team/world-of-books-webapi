using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldOfBooks.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookStarMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "AverageStars",
                table: "BookStars",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageStars",
                table: "BookStars");
        }
    }
}
