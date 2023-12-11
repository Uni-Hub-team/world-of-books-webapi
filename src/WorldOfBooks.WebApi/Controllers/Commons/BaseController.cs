using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WorldOfBooks.WebApi.Controllers.Commons;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class BaseController : ControllerBase
{ }
