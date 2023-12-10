using WorldOfBooks.Application.Exceptions;

namespace WorldOfBooks.Application.Categories.Users;

public class CategoryAlreadyExistsException : AlreadyExistsException
{
    public CategoryAlreadyExistsException()
    {
        TitleMessage = "User already exists";
    }
}
