using Microsoft.AspNetCore.Mvc;
using WorldOfBooks.Service.Interfaces.Authors;

namespace WorldOfBooks.WebApi.Controllers.Commons.Authors;

[Route("api/common/author")]
[ApiController]
public class CommonAuthorController : BaseController
{
    private IAuthorService _authorService;

    public CommonAuthorController(IAuthorService service)
    {
        _authorService = service;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(await _authorService.GetAllAsync());

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
        => Ok(await _authorService.GetByIdAsync(Id));
}
