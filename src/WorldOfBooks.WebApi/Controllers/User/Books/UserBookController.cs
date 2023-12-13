using Microsoft.AspNetCore.Mvc;
using WorldOfBooks.Service.Interfaces.Books;

namespace WorldOfBooks.WebApi.Controllers.User.Books;

[Route("api/user/book")]
[ApiController]
public class UserBookController : BaseUserController
{
    private IBookService _bookService;

    public UserBookController(IBookService service)
    {
        _bookService = service;
    }

    [HttpGet("source/{Id}")]
    public async Task<IActionResult> GetByIdSourceAsync(long Id)
        => Ok(await _bookService.GetByIdSourceAsync(Id));

    [HttpGet("audio/{Id}")]
    public async Task<IActionResult> GetByIdAudioAsync(long Id)
       => Ok(await _bookService.GetByIdAudioAsync(Id));
}
