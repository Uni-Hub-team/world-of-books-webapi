using WorldOfBooks.Persistence.ViewModels.Books;
using WorldOfBooks.Persistence.ViewModels.User;

namespace WorldOfBooks.Persistence.Dtos.Comments;

public class CommentResultDto
{
    public string Text { get; set; } = string.Empty;
    public BookResult Book { get; set; }
    public UserResultDto User { get; set; }
}