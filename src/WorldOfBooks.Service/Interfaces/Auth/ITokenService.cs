namespace WorldOfBooks.Service.Interfaces.Auth;

public interface ITokenService
{
    Task<string> GenerateTokenAsync(WorldOfBooks.Domain.Entities.Users.User user);
}