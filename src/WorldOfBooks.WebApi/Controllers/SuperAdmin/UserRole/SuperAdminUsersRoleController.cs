using Microsoft.AspNetCore.Mvc;

namespace WorldOfBooks.WebApi.Controllers.SuperAdmin.UserRole;

[Route("api/[controller]")]
[ApiController]
public class SuperAdminUsersRoleController : BaseSuperAdminController
{
    //private readonly IUserRoleService _service;
    private int maxPage = 30;

    public SuperAdminUsersRoleController()
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok();

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
        => Ok();


    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id)
        =>Ok();
}
