using Microsoft.AspNetCore.Http;

namespace WorldOfBooks.Persistence.Dtos.User;

public class UserUpdateImageDto
{
    public IFormFile Image { get; set; } = default!;
}
