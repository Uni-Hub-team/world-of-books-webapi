namespace WorldOfBooks.Persistence.Dtos.Categories;

public class SubCategoryCreateDto
{
    public string Name { get; set; } = string.Empty;
    public long CategoryId { get; set; }
}
