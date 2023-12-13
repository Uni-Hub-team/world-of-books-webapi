namespace WorldOfBooks.Persistence.Dtos.Comments;

public class CommentCreationDto
{
    public string Text { get; set; } = string.Empty;
    public long BookId { get; set; }
    public long UserId { get; set; }
}