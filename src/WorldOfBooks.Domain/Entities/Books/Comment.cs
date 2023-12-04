using WorldOfBooks.Domain.Commons;

namespace WorldOfBooks.Domain.Entities.Books;

public class Comment : Auditable
{
    public long BookId { get; set; }
    public long UserId { get; set; }
    public string Text { get; set; } = string.Empty;
}
