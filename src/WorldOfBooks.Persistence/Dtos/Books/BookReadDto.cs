using WorldOfBooks.Domain.Commons;

namespace WorldOfBooks.Persistence.Dtos.Books;

public class BookReadDto : Auditable
{
    public long BookId { get; set; }
}
