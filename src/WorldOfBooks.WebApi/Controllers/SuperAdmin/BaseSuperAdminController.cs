using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WorldOfBooks.WebApi.Controllers.SuperAdmin;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "SuperAdmin")]
public class BaseSuperAdminController : ControllerBase
{
}
