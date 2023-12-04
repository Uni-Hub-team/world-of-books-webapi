namespace WorldOfBooks.Persistence.ViewModels.Auth;

public class VerifyResult
{
    public bool Result { get; set; }
    public string Token { get; set; } = string.Empty;
}
