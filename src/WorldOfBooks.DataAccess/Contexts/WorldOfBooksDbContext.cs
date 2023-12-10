using Microsoft.EntityFrameworkCore;
using WorldOfBooks.Domain.Entities.Authors;
using WorldOfBooks.Domain.Entities.Books;
using WorldOfBooks.Domain.Entities.Categories;
using WorldOfBooks.Domain.Entities.Users;

namespace WorldOfBooks.DataAccess.Contexts;

public class WorldOfBooksDbContext : DbContext
{
    public WorldOfBooksDbContext(DbContextOptions<WorldOfBooksDbContext> options) : base(options)
    {
    }

    DbSet<User> Users { get; set; }
    DbSet<Author> Author { get; set; }
    DbSet<Book> Books { get; set; }
    DbSet<BookStar> BookStars { get; set; }
    DbSet<Comment> Comments { get; set; }
    DbSet<Read> Reads { get; set; }
    DbSet<View> Views { get; set; }
    DbSet<Category> Category { get; set; }
    DbSet<SubCategory> SubCategory { get; set; }
    DbSet<UserSortedBook> UserSortedBook { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Filtering "IsDeleted" status for entities
        modelBuilder.Entity<Author>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Book>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<User>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<BookStar>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Comment>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Read>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<View>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Category>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<SubCategory>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<UserSortedBook>().HasQueryFilter(e => !e.IsDeleted);
        #endregion
    }
}
