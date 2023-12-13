using WorldOfBooks.Domain.Commons;
using WorldOfBooks.Domain.Entities.Categories;

namespace WorldOfBooks.Persistence.Dtos.Categories;

public class SubCategoryResultDto : Auditable
{
    public string Name { get; set; } = string.Empty;
    public Category Category { get; set; }
}
