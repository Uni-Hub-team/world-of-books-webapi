using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WorldOfBooks.WebApi.Controllers.User;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "User")]
public class BaseUserController : ControllerBase
{ }