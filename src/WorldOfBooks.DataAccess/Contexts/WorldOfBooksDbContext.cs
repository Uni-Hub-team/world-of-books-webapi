using Microsoft.EntityFrameworkCore;
using WorldOfBooks.Domain.Entities.Authors;
using WorldOfBooks.Domain.Entities.Books;
using WorldOfBooks.Domain.Entities.Categories;
using WorldOfBooks.Domain.Entities.Users;

namespace WorldOfBooks.DataAccess.Contexts;

public class WorldOfBooksDbContext : DbContext
{
    public WorldOfBooksDbContext(DbContextOptions<WorldOfBooksDbContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Author> Author { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookStar> BookStars { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Read> Reads { get; set; }
    public DbSet<View> Views { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<UserSortedBook> UserSortedBooks { get; set; }

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
