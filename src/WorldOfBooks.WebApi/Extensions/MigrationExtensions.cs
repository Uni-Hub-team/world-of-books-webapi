using Microsoft.EntityFrameworkCore;
using WorldOfBooks.DataAccess.Contexts;

namespace WorldOfBooks.WebApi.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            try
            {
                var dbContext = scope.ServiceProvider.GetService<WorldOfBooksDbContext>();
                dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                throw new Exception($"Migration failed: {ex.Message}");
            }
        }
    }
}