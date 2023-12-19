namespace WorldOfBooks.Persistence.Dtos.Books;

public class BookStarCreationDto
{
    public int Star { get; set; }
    public long BookId { get; set; }
    public long UserId { get; set; }
}