using Microsoft.AspNetCore.Mvc;
using WorldOfBooks.Persistence.Dtos.Categories;
using WorldOfBooks.Service.Interfaces.Categories;

namespace WorldOfBooks.WebApi.Controllers.Admin.Categories;

[Route("api/admin/sub-category")]
[ApiController]
public class AdminSubCategoryController : BaseAdminController
{
    private ISubCategoryService _subCategoryService;

    public AdminSubCategoryController(ISubCategoryService service)
    {
        _subCategoryService = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreatedAsync([FromBody] SubCategoryCreateDto dto)
        => Ok(await _subCategoryService.CreateAsync(dto));

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, [FromBody] SubCategoryUpdateDto dto)
        => Ok(await _subCategoryService.UpdateAsync(Id, dto));

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
        => Ok(await _subCategoryService.DeleteAsync(Id));
}
