using Microsoft.AspNetCore.Mvc;
using WorldOfBooks.Persistence.Dtos.Auth;
using WorldOfBooks.Persistence.Dtos.User;
using WorldOfBooks.Service.Interfaces.Auth;

namespace WorldOfBooks.WebApi.Controllers.Commons.Auth;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    private IAuthService _service;

    public AuthController(IAuthService authService)
    {
        _service = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromForm] UserCreateDto dto)
    {
        //UserRegisterValidator validations = new UserRegisterValidator();
        //var resltvalid = validations.Validate(dto);
        if (true)
        {
            var result = await _service.RegisterAsync(dto);

            return Ok(result);
        }
    }

    [HttpPost("register/send-code")]
    public async Task<IActionResult> SendCodeAsync([FromBody] SendCodeDto dto)
    {
        // var valid = PhoneNumberValidator.IsValid(phone);
        if (true)
        {
            var result = await _service.SendCodeForRegister(dto);

            return Ok(result);
        }

    }

    [HttpPost("register/verify")]
    public async Task<IActionResult> VerifyRegisterAsync([FromBody] VerifyCode dto)
    {
        //var res = PhoneNumberValidator.IsValid(dto.PhoneNumber);
        //if (res == false) return BadRequest("Phone number is invalid!");
        var srResult = await _service.VerifyRegisterAsync(dto);

        return Ok(new { srResult.Result, srResult.Token });
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] UserLoginDto dto)
    {
        /*  var res = PhoneNumberValidator.IsValid(dto.PhoneNumber);
          if (res == false)
              return BadRequest("Phone number is invalid!");*/

        var serviceResult = await _service.LoginAsync(dto);

        return Ok(serviceResult);
    }
}
