using WorldOfBooks.Domain.Commons;
using WorldOfBooks.Domain.Enums;

namespace WorldOfBooks.Domain.Entities.Categories;

public class Category : Auditable
{
    public string Name { get; set; } = string.Empty;
    public Status status { get; set; }
}
