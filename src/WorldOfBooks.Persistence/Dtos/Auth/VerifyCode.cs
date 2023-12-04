namespace WorldOfBooks.Persistence.Dtos.Auth;

public class VerifyCode
{
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Code { get; set; }
}
