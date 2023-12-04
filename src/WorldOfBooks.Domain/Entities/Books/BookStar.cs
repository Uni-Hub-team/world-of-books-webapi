using WorldOfBooks.Domain.Commons;

namespace WorldOfBooks.Domain.Entities.Books;

public class BookStar : Auditable
{
    public long BookId { get; set; }
    public long UserId { get; set; }
    public int Star {  get; set; } 
}
