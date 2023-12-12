using Microsoft.AspNetCore.Http;

namespace WorldOfBooks.Persistence.Dtos.Books;

public class BookCreateDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IFormFile Source { get; set; } = default!;
    public IFormFile Image { get; set; } = default!;
    public IFormFile Audio { get; set; } = default!;
    public long CategoryId { get; set; }
    public long SubCategoryId { get; set; }
    public long AuthorId { get; set; }
}