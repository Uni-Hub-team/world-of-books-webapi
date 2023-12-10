namespace WorldOfBooks.Application.Exceptions.Users;

public class UserAlreadyExistsException : AlreadyExistsException
{
    public UserAlreadyExistsException()
    {
        TitleMessage = "User already exists";
    }
}
