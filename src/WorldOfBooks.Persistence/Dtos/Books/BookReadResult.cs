using WorldOfBooks.Domain.Commons;

namespace WorldOfBooks.Persistence.Dtos.Books;

public class BookReadResult : Auditable
{
    public long BookId { get; set; }
    public long Count { get; set; }
}
