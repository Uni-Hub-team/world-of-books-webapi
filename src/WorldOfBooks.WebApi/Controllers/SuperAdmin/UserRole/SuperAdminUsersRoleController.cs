using Microsoft.AspNetCore.Mvc;
using WorldOfBooks.Persistence.Dtos.RoleDto;
using WorldOfBooks.Service.Interfaces.User;

namespace WorldOfBooks.WebApi.Controllers.SuperAdmin.UserRole;

[Route("api/super-admin/user/roles")]
[ApiController]
public class SuperAdminUsersRoleController : BaseSuperAdminController
{
    //private readonly IUserRoleService _service;
    private int maxPage = 30;
    private IUserService _userService;

    public SuperAdminUsersRoleController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
        => Ok(await _userService.GetByIdAsync(Id));


    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, [FromBody] UserRoleUpdateDto dto)
        => Ok(await _userService.UpgradeRoleAsync(Id, dto));
}
