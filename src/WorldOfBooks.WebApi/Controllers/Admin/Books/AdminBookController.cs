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

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, [FromForm] BookUpdateDto dto)
        => Ok(await _bookService.UpdateAsync(Id, dto));

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
        => Ok(await _bookService.DeleteAsync(Id));
}
