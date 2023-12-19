using WorldOfBooks.Domain.Commons;

namespace WorldOfBooks.Persistence.Dtos.Categories;

public class SubCategoryResultDto : Auditable
{
    public string Name { get; set; } = string.Empty;
}