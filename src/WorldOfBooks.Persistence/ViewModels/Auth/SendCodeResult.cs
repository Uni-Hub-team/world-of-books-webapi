namespace WorldOfBooks.Persistence.ViewModels.Auth;

public class SendCodeResult
{
    public bool Result { get; set; }
    public int CachedVerificationMinutes { get; set; }
}
