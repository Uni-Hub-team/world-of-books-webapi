using WorldOfBooks.Domain.Commons;

namespace WorldOfBooks.Domain.Entities.Books;

public class View : Auditable
{
    public long User { get; set; }
    public long Anonym { get; set; }
    public long All { get; set; }

    public long BookId { get; set; }
    public Book? Book { get; set; }
}