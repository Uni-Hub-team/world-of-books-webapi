using WorldOfBooks.Domain.Commons;

namespace WorldOfBooks.Domain.Entities.Books;

public class Book : Auditable
{
    public long CategoryId { get; set; }
    public long SubCategoryId { get; set; }
    public long AuthorId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string AudioPath { get; set; } = string.Empty;
}
