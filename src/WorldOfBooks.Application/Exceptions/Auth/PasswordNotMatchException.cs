namespace WorldOfBooks.Application.Exceptions.Auth;

public class PasswordNotMatchException : BadRequestException
{
    public PasswordNotMatchException()
    {
        this.TitleMessage = "Password is invalid!";
    }
}
