namespace WorldOfBooks.Persistence.Dtos.Auth;

public class SendCodeDto
{
    public string Phone { get; set; }  = string.Empty;
    public string Email { get; set; } = string.Empty;
}
