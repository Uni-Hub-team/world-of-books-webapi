using Microsoft.AspNetCore.Http;

namespace WorldOfBooks.Persistence.Dtos.Books;

public class BookUpdateDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public long CategoryId { get; set; }
    public long SubCategoryId { get; set; }
    public long AuthorId { get; set; }
}
