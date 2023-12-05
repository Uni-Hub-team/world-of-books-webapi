using WorldOfBooks.Domain.Commons;
using WorldOfBooks.Domain.Entities.Users;

namespace WorldOfBooks.Domain.Entities.Books;

public class Read : Auditable
{
    public long BookId { get; set; }
    public Book? Book { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
}
