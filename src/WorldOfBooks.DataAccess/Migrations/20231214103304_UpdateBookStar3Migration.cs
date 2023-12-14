using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldOfBooks.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookStar3Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "AverageStars",
                table: "BookStars",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "AverageStars",
                table: "BookStars",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
