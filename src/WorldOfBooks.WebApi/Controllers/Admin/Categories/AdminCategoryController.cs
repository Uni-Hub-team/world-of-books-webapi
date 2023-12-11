using Microsoft.AspNetCore.Mvc;
using WorldOfBooks.Domain.Enums;
using WorldOfBooks.Persistence.Dtos.Categories;
using WorldOfBooks.Service.Interfaces.Categories;

namespace WorldOfBooks.WebApi.Controllers.Admin.Categories;

[Route("api/admin/category")]
[ApiController]
public class AdminCategoryController : BaseAdminController
{
    private ICategoryService _categoryService;

    public AdminCategoryController(ICategoryService service)
    {
        _categoryService = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto dto)
        => Ok(await _categoryService.CreateAsync(dto));

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, [FromBody] CategoryUpdateDto dto)
        => Ok(await _categoryService.UpdateAsync(Id, dto));

    [HttpPut("status/{Id}")]
    public async Task<IActionResult> UpdateStatusAsync(long Id, [FromBody] Status status)
        => Ok(await _categoryService.UpgradeStatusAsync(Id, status));

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
        => Ok(await _categoryService.DeleteAsync(Id));
}
