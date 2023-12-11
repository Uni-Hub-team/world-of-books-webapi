using Microsoft.AspNetCore.Mvc;
using WorldOfBooks.Service.Interfaces.User;

namespace WorldOfBooks.WebApi.Controllers.Admin.User;

[Route("api/admin/user")]
[ApiController]
public class AdminUsersController : BaseAdminController
{
    private IUserService _userService;

    public AdminUsersController(IUserService service)
    {
        _userService = service;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
        => Ok(await _userService.GetByIdAsync(Id));

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(await _userService.GetAllAsync());

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
        => Ok(await _userService.DeleteAsync(Id));
}
