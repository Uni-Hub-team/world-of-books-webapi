using WorldOfBooks.Domain.Commons;
using WorldOfBooks.Domain.Entities.Books;

namespace WorldOfBooks.Domain.Entities.Users;

public class UserSortedBook : Auditable
{
    public bool Like { get; set; }
    public long BookId { get; set; }
    public Book? Book { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
}
