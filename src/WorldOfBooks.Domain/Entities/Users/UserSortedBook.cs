using WorldOfBooks.Domain.Commons;

namespace WorldOfBooks.Domain.Entities.Users;

public class UserSortedBook : Auditable
{
    public long BookId { get; set; }
    public long UserId { get; set; }
    public bool Like { get; set; }
}
