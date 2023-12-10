using Microsoft.EntityFrameworkCore;
using WorldOfBooks.DataAccess.Contexts;

namespace WorldOfBooks.WebApi.Extensions;

public static class DataExtensions
{
    public static void ApplyMigrations(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<WorldOfBooksDbContext>();
            //db.Database.Migrate();
        }
    }
}
