using WorldOfBooks.Domain.Commons;
using WorldOfBooks.Domain.Enums;

namespace WorldOfBooks.Persistence.Dtos.Categories;

public class CategoryResultDto : Auditable
{
    public string Name { get; set; } = string.Empty;
    public Status Status { get; set; }
    public IEnumerable<SubCategoryResultDto> SubCategories { get; set; }
}