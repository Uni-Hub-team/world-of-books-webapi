using Microsoft.AspNetCore.Mvc;
using WorldOfBooks.Persistence.Dtos.Books;
using WorldOfBooks.Service.Interfaces.Auth;
using WorldOfBooks.Service.Interfaces.Books;

namespace WorldOfBooks.WebApi.Controllers.User.Books;

[ApiController]
[Route("api/user/book")]
public class UserBookController : BaseUserController
{
    private IBookReadService _readService;
    private IBookService _bookService;
    private IIdentityService _identitiyId;

    public UserBookController(
        IBookService service,
        IBookReadService readService,
        IIdentityService identity)
    {
        _readService = readService;
        _bookService = service;
        _identitiyId = identity;
    }

    [HttpGet("source/{Id}")]
    public async Task<IActionResult> GetByIdSourceAsync(long Id)
    {
        var result = await _bookService.GetByIdSourceAsync(Id);

        BookReadDto readDto = new BookReadDto();
        readDto.BookId = Id;

        await _readService.CreateAsync(_identitiyId.Id, readDto);

        return Ok(result);
    }

    [HttpGet("audio/{Id}")]
    public async Task<IActionResult> GetByIdAudioAsync(long Id)
    {
        var result = await _bookService.GetByIdAudioAsync(Id);

        BookReadDto readDto = new BookReadDto();
        readDto.BookId = Id;
        await _readService.CreateAsync(_identitiyId.Id, readDto);

        return Ok(result);
    }
}
