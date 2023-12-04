using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using WorldOfBooks.Application.Exceptions.Users;
using WorldOfBooks.DataAccess.IRepositories;
using WorldOfBooks.Domain.Entities.Users;
using WorldOfBooks.Persistence.Dtos.Auth;
using WorldOfBooks.Persistence.Dtos.User;
using WorldOfBooks.Persistence.ViewModels.Auth;
using WorldOfBooks.Service.Interfaces.Auth;

namespace WorldOfBooks.Service.Service.Auth;

public class AuthService : IAuthService
{
    private const int CACHED_FOR_MINUTS_REGISTER = 60;
    private const int CACHED_FOR_MINUTS_VEFICATION = 5;
    private const int VERIFICATION_MAXIMUM_ATTEMPTS = 3;

    private const string REGISTER_CACHE_KEY = "register_";
    private const string VERIFY_REGISTER_CACHE_KEY = "verify_register_";
    private const string Reset_CACHE_KEY = "reset_";
    private IMapper _mapper;
    private IRepository<User> _userRepository;
    private IMemoryCache _memoryCache;

    public AuthService(
        IMapper mapper,
        IRepository<User> userRepository,
        IMemoryCache memory)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _memoryCache = memory;
    }

    public Task<LoginResult> LoginAsync(UserLoginDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<RegisterResult> RegisterAsync(UserCreateDto dto)
    {
        var dbResult = await _userRepository.SelectAsync(user => user.Phone.Equals(dto.Phone));

        if (dbResult is not null)
            throw new UserAlreadyExistsException();

        if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + dto.Phone, out UserCreateDto userDto))
        {
            userDto.Phone = userDto.Phone;
            _memoryCache.Remove(dto.Phone);
        }
        else
        {
            _memoryCache.Set(REGISTER_CACHE_KEY + dto.Phone, dto, TimeSpan.FromMinutes
                (CACHED_FOR_MINUTS_REGISTER));
        }

        RegisterResult register = new RegisterResult
        {
            Result = true,
            CacheRegisterMinutes = CACHED_FOR_MINUTS_REGISTER
        };

        return register;
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
