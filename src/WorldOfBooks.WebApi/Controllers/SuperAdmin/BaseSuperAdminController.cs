using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WorldOfBooks.WebApi.Controllers.SuperAdmin;

[ApiController]
[Route("api/[controller]")]
//[Authorize(Roles = "SuperAdmin")]
public class BaseSuperAdminController : ControllerBase
{ }