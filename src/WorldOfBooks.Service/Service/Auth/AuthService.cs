using WorldOfBooks.Persistence.Dtos.Auth;
using WorldOfBooks.Persistence.Dtos.User;
using WorldOfBooks.Persistence.ViewModels.Auth;
using WorldOfBooks.Service.Interfaces.Auth;

namespace WorldOfBooks.Service.Service.Auth;

public class AuthService : IAuthService
{
    public Task<LoginResult> LoginAsync(UserLoginDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<RegisterResult> RegisterAsync(UserCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<SendCodeResult> SendCodeForRegister(SendCodeDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<VerifyResult> VerifyRegisterAsync(VerifyCode dto)
    {
        throw new NotImplementedException();
    }
}
