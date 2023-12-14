using WorldOfBooks.Domain.Commons;
using WorldOfBooks.Persistence.ViewModels.Books;
using WorldOfBooks.Persistence.ViewModels.User;

namespace WorldOfBooks.Persistence.Dtos.Books;

public class BookStarResultDto : Auditable
{
    public int Star { get; set; }
    public float AverageStars { get; set; }
    public BookResult Book { get; set; }
    public UserResultDto User { get; set; }
}