namespace WorldOfBooks.Persistence.ViewModels.Auth;

public class LoginResult
{
    public bool Result { get; set; }
    public string Token { get; set; } = string.Empty;
}
