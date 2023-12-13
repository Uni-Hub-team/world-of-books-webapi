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

}
