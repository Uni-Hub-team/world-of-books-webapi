namespace WorldOfBooks.Persistence.Dtos.Categories;

public class SubCategoryUpdateDto
{
    public string Name { get; set; } = string.Empty;
    public long CategoryId { get; set; }
}
