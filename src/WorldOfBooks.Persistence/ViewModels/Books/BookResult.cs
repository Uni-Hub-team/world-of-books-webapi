using WorldOfBooks.Domain.Commons;

namespace WorldOfBooks.Persistence.ViewModels.Books;

public class BookResult : Auditable
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public bool Audio { get; set; } = false;
    public long CategoryId { get; set; }
    public long SubCategoryId { get; set; }
    public long AuthorId { get; set; }
}
