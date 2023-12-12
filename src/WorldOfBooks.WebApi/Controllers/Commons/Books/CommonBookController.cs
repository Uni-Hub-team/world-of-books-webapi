using Microsoft.AspNetCore.Mvc;
using WorldOfBooks.Service.Interfaces.Books;

namespace WorldOfBooks.WebApi.Controllers.Commons.Books;

[Route("api/admin/book")]
[ApiController]
public class CommonBookController : ControllerBase
{
    private IBookService _bookService;

    public CommonBookController(IBookService service)
    {
        _bookService = service;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(await _bookService.GetAllAsync());
}
