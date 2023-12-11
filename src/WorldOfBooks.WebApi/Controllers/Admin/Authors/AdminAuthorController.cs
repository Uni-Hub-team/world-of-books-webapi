using Microsoft.AspNetCore.Mvc;
using WorldOfBooks.Persistence.Dtos.Authors;
using WorldOfBooks.Service.Interfaces.Authors;

namespace WorldOfBooks.WebApi.Controllers.Admin.Authors;

[Route("api/admin/author")]
[ApiController]
public class AdminAuthorController : BaseAdminController
{
    private IAuthorService _authorService;

    public AdminAuthorController(IAuthorService service)
    {
        _authorService = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] AuthorCreateDto dto)
        => Ok(await _authorService.CreateAsync(dto));

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, [FromBody] AuthorUpdateDto dto)
        => Ok(await _authorService.UpdateAsync(Id, dto));

    [HttpPut("image/{Id}")]
    public async Task<IActionResult> UpdateImageAsync(long Id, IFormFile file)
        => Ok(await _authorService.UpdateImageAsync(Id, file));

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
        => Ok(await _authorService.DeleteAsync(Id));
}
