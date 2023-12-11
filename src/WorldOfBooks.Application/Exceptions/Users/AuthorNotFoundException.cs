namespace WorldOfBooks.Application.Exceptions.Authors;

public class AuthorNotFoundException : NotFoundException
{
    public AuthorNotFoundException()
    {
        this.TitleMessage = "Author not found";
    }
}
