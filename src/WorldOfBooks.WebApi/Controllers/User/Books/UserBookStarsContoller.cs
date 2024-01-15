using Microsoft.AspNetCore.Mvc;
using WorldOfBooks.Persistence.Dtos.Books;
using WorldOfBooks.Service.Interfaces.Books;

namespace WorldOfBooks.WebApi.Controllers.User.Books;


[Route("api/user/book-stars")]
[ApiController]
public class UserBookStarsContoller : BaseUserController
{
    private readonly IBookStarService _bookStarService;
    public UserBookStarsContoller(IBookStarService bookStarService)
    {
        _bookStarService = bookStarService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] BookStarCreationDto dto)
       => Ok(await _bookStarService.CreateAsync(dto));

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, [FromBody] BookStarUpdateDto dto)
        => Ok(await _bookStarService.UpdateAsync(Id, dto));

    [HttpGet("userId")]
    public async Task<IActionResult> GetByUserIdAsync(long userId)
        => Ok(await _bookStarService.GetByUserIdAsync(userId));
}