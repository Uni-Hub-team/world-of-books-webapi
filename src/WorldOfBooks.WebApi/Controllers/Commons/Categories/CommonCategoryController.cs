using Microsoft.AspNetCore.Mvc;
using WorldOfBooks.Service.Interfaces.Categories;

namespace WorldOfBooks.WebApi.Controllers.Commons.Categories;

[Route("api/common/category")]
[ApiController]
public class CommonCategoryController : BaseController
{
    private ICategoryService _categoryService;

    public CommonCategoryController(ICategoryService service)
    {
        _categoryService = service;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
        => Ok(await _categoryService.GetByIdAsync(Id));

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(await _categoryService.GetAllAsync());
}
