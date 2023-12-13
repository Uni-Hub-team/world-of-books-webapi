using WorldOfBooks.Domain.Commons;

namespace WorldOfBooks.Domain.Entities.Categories;

public class SubCategory : Auditable
{
    public string Name { get; set; } = string.Empty;

    public long CategoryId { get; set; }
    public Category Category { get; set; }
}
