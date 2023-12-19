using Microsoft.AspNetCore.Mvc;
using WorldOfBooks.Service.Interfaces.Books;

namespace WorldOfBooks.WebApi.Controllers.Commons.Books;

[Route("api/[controller]")]
[ApiController]
public class CommonBookStarController : BaseController
{
    private IBookStarService _bookStarService;

    public CommonBookStarController(IBookStarService bookStarService)
    {
        _bookStarService = bookStarService;
    }

    [HttpGet("bookId")]
    public async Task<IActionResult> GetByBookIdAsync(long bookId)
       => Ok(await _bookStarService.GetByBookIdAsync(bookId));


    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(await _bookStarService.GetAllAsync());
}
