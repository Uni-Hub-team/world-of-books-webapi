namespace WorldOfBooks.Service.Interfaces.Auth;

public interface ITokenService
{
    Task<string> GenerateTokenAsync(User user);
}