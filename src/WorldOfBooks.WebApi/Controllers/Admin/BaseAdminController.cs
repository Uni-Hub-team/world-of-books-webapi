using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WorldOfBooks.WebApi.Controllers.Admin;

[ApiController]
[Route("api/[controller]")]
//[Authorize(Roles = "SuperAdmin, Admin")]
public class BaseAdminController : ControllerBase
{ }
