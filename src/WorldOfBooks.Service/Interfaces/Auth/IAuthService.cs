using WorldOfBooks.Persistence.Dtos.Auth;
using WorldOfBooks.Persistence.Dtos.User;
using WorldOfBooks.Persistence.ViewModels.Auth;

namespace WorldOfBooks.Service.Interfaces.Auth;

public interface IAuthService
{
    Task<RegisterResult> RegisterAsync(UserCreateDto dto);
    Task<SendCodeResult> SendCodeForRegister(SendCodeDto dto);
    Task<VerifyResult> VerifyRegisterAsync(VerifyCode dto);
    Task<LoginResult> LoginAsync(UserLoginDto dto);
}
