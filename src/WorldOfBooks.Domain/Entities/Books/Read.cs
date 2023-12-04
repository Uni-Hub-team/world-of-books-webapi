using WorldOfBooks.Domain.Commons;

namespace WorldOfBooks.Domain.Entities.Books;

public class Read : Auditable
{
    public long BookId { get; set; }
    public long UserId { get; set; }
}
