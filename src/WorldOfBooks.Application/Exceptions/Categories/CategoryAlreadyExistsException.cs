namespace WorldOfBooks.Application.Exceptions.Users;

public class CategoryAlreadyExistsException : AlreadyExistsException
{
    public CategoryAlreadyExistsException()
    {
        TitleMessage = "User already exists";
    }
}
