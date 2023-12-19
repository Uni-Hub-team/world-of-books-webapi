namespace WorldOfBooks.Persistence.Dtos.Books;

public class BookStarUpdateDto
{
    public int Star { get; set; }
    public long BookId { get; set; }
    public long UserId { get; set; }
}
