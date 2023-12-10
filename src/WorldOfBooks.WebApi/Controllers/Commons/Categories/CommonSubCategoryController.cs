using Microsoft.AspNetCore.Mvc;
using WorldOfBooks.Service.Interfaces.Categories;

namespace WorldOfBooks.WebApi.Controllers.Commons.Categories;

[Route("api/common/sub-category")]
[ApiController]
public class CommonSubCategoryController : ControllerBase
{
    private ISubCategoryService _subCategoryService;

    public CommonSubCategoryController(ISubCategoryService service)
    {
        _subCategoryService = service;
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
        => Ok(await _subCategoryService.GetByIdAsync(Id));

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(await _subCategoryService.GetAllAsync());
}
