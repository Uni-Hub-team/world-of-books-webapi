namespace WorldOfBooks.Application.Exceptions.Authors;

public class AuthorAlreadyExistsException : AlreadyExistsException
{
    public AuthorAlreadyExistsException()
    {
        TitleMessage = "Author already exists";
    }
}
