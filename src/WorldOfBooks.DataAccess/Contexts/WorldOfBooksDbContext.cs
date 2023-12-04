using Microsoft.EntityFrameworkCore;
using WorldOfBooks.Domain.Entities.Users;

namespace WorldOfBooks.DataAccess.Contexts;

public class WorldOfBooksDbContext : DbContext
{
    public WorldOfBooksDbContext(DbContextOptions<WorldOfBooksDbContext> options) : base(options)
    {
    }

    DbSet<User> Users { get; set; }
}
