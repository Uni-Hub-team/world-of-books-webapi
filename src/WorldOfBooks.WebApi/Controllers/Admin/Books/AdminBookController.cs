using Microsoft.AspNetCore.Mvc;
using WorldOfBooks.Persistence.Dtos.Books;
using WorldOfBooks.Service.Interfaces.Books;

namespace WorldOfBooks.WebApi.Controllers.Admin.Books;

[Route("api/admin/book")]
[ApiController]
public class AdminBookController : BaseAdminController
{
    private IBookService _bookService;

    public AdminBookController(IBookService service)
    {
        _bookService = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] BookCreateDto dto)
        => Ok(await _bookService.CreateAsync(dto));

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    => Ok(await _bookService.DeleteAsync(Id));

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, [FromForm] BookUpdateDto dto)
        => Ok(await _bookService.UpdateAsync(Id, dto));

    [HttpPut("image/{Id}")]
    public async Task<IActionResult> UpdateImageAsync(long Id, IFormFile Image)
        => Ok(await _bookService.UpdateBookImageAsync(Id, Image));

    [HttpPut("source/{Id}")]
    public async Task<IActionResult> UpdateSourceAsync(long Id, IFormFile Source)
        => Ok(await _bookService.UpdateBookSourceAsync(Id, Source));

    [HttpPut("audio/{Id}")]
    public async Task<IActionResult> UpdateAudioAsync(long Id, IFormFile Audio)
        => Ok(await _bookService.UpdateBookAudioAsync(Id, Audio));
}
