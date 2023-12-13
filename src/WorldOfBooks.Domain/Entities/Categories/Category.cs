using WorldOfBooks.Domain.Commons;
using WorldOfBooks.Domain.Entities.Books;
using WorldOfBooks.Domain.Enums;

namespace WorldOfBooks.Domain.Entities.Categories;

public class Category : Auditable
{
    public string Name { get; set; } = string.Empty;
    public Status Status { get; set; }

    public ICollection<Book> Books { get; set; }
    public ICollection<SubCategory> SubCategories { get; set; }
}