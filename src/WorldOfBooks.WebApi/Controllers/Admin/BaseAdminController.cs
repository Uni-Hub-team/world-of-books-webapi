using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WorldOfBooks.WebApi.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class BaseAdminController : ControllerBase
    {
    }
}
