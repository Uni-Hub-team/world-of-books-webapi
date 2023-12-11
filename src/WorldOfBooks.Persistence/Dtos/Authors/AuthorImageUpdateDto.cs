using Microsoft.AspNetCore.Http;

namespace WorldOfBooks.Persistence.Dtos.Authors;

public class AuthorImageUpdateDto
{
    public IFormFile Images {  get; set; } = default!;
}
