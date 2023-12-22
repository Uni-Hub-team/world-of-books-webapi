using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using WorldOfBooks.Application.Exceptions;
using WorldOfBooks.Application.Exceptions.Auth;
using WorldOfBooks.Application.Exceptions.Users;
using WorldOfBooks.DataAccess.IRepositories;
using WorldOfBooks.Domain.Entities.Users;
using WorldOfBooks.Persistence.Dtos;
using WorldOfBooks.Persistence.Dtos.Auth;
using WorldOfBooks.Persistence.Dtos.User;
using WorldOfBooks.Persistence.ViewModels.Auth;
using WorldOfBooks.Service.Commons.Helpers;
using WorldOfBooks.Service.Commons.Security;
using WorldOfBooks.Service.Interfaces.Auth;
using WorldOfBooks.Service.Interfaces.Notifications;

namespace WorldOfBooks.Service.Service.Auth;

public class AuthService : IAuthService
{
    private const int CACHED_FOR_MINUTS_REGISTER = 60;
    private const int CACHED_FOR_MINUTS_VEFICATION = 5;
    private const int VERIFICATION_MAXIMUM_ATTEMPTS = 3;

    private const string REGISTER_CACHE_KEY = "register_";
    private const string VERIFY_REGISTER_CACHE_KEY = "verify_register_";
    private const string Reset_CACHE_KEY = "reset_";
    private ISmsSender _smsSend;
    private IEmailsender _emailSend;
    private ITokenService _tokenService;
    private IMapper _mapper;
    private IRepository<User> _userRepository;
    private IMemoryCache _memoryCache;

    public AuthService(
        IMapper mapper,
        IRepository<User> userRepository,
        IMemoryCache memory,
        ITokenService token,
        IEmailsender emailSender,
        ISmsSender smsSender
)
    {
        _smsSend = smsSender;
        _emailSend = emailSender;
        _tokenService = token;
        _mapper = mapper;
        _userRepository = userRepository;
        _memoryCache = memory;
    }

    public async Task<LoginResult> LoginAsync(UserLoginDto dto)
    {
        var existUser = await _userRepository.SelectAsync(user => user.Phone.Equals(dto.Login))
            ?? throw new UserNotFoundException();

        var hasherResult = PasswordHasher.Verify(dto.Password, existUser.PasswordHash, existUser.Salt);
        if (!hasherResult)
            throw new PasswordNotMatchException();

        var token = await _tokenService.GenerateTokenAsync(existUser);

        LoginResult authResult = new LoginResult()
        {
            Result = true,
            Token = token
        };

        return authResult;
    }

    public async Task<RegisterResult> RegisterAsync(UserCreateDto dto)
    {
        var dbResult = await _userRepository.SelectAsync(user => user.Phone.Equals(dto.Phone) || user.Email.Equals(dto.Email));

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

    public async Task<SendCodeResult> SendCodeForRegister(SendCodeDto dto)
    {
        if (dto.Phone is not null)
        {
            if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + dto.Phone, out UserCreateDto userCreate))
            {
                VerificationDto verificationDto = new VerificationDto();
                verificationDto.Attempt = 0;
                verificationDto.CreatedAt = DateTime.UtcNow;
                verificationDto.Code = CodeGenerator.RandomCodeGenerator();
                _memoryCache.Set(userCreate.Phone, verificationDto, TimeSpan.FromMinutes(CACHED_FOR_MINUTS_VEFICATION));

                if (_memoryCache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + userCreate.Phone,
                    out VerificationDto OldverificationDto))
                {
                    _memoryCache.Remove(userCreate.Phone);
                }

                _memoryCache.Set(VERIFY_REGISTER_CACHE_KEY + userCreate.Phone, verificationDto,
                    TimeSpan.FromMinutes(VERIFICATION_MAXIMUM_ATTEMPTS));

                SmsSenderDto smsSenderDto = new SmsSenderDto();
                smsSenderDto.Title = "Kitoblar Olami\n";
                smsSenderDto.Content = "Sizning tasdiqlash kodingiz : " + verificationDto.Code;
                smsSenderDto.Recipient = userCreate.Phone.Substring(1);
                var result = await _smsSend.SendAsync(smsSenderDto);

                if (result is true)
                {
                    SendCodeResult sendCode = new SendCodeResult()
                    {
                        Result = true,
                        CachedVerificationMinutes = CACHED_FOR_MINUTS_VEFICATION
                    };

                    return sendCode;
                }
                else
                {
                    SendCodeResult sendCode = new SendCodeResult()
                    {
                        Result = false,
                        CachedVerificationMinutes = 0
                    };

                    return sendCode;
                }
            }
            else
            {
                throw new ExpiredException();
            }
        }
        else if (dto.Email is not null)
        {
            if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + dto.Email, out UserCreateDto registerDto))
            {
                VerificationDto verificationDto = new VerificationDto();
                verificationDto.Attempt = 0;
                verificationDto.CreatedAt = TimeHelper.GetDateTime();
                verificationDto.Code = CodeGenerator.RandomCodeGenerator();
                _memoryCache.Set(dto.Email, verificationDto, TimeSpan.FromMinutes(CACHED_FOR_MINUTS_VEFICATION));

                if (_memoryCache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + dto.Email,
                    out VerificationDto OldverificationDto))
                {
                    _memoryCache.Remove(dto.Email);
                }

                _memoryCache.Set(VERIFY_REGISTER_CACHE_KEY + dto.Email, verificationDto,
                    TimeSpan.FromMinutes(VERIFICATION_MAXIMUM_ATTEMPTS));

                EmailSenderDto smsSenderDto = new EmailSenderDto();
                smsSenderDto.Title = "Kitoblar Olami\n";
                smsSenderDto.Content = "Sizning tasdiqlash kodingiz : " + verificationDto.Code;
                smsSenderDto.Recipient = dto.Email;
                var result = await _emailSend.SenderAsync(smsSenderDto);

                if (result is true)
                {
                    SendCodeResult sendCode = new SendCodeResult()
                    {
                        Result = true,
                        CachedVerificationMinutes = CACHED_FOR_MINUTS_VEFICATION
                    };

                    return sendCode;
                }
                else
                {
                    SendCodeResult sendCode = new SendCodeResult()
                    {
                        Result = false,
                        CachedVerificationMinutes = 0
                    };

                    return sendCode;
                }
            }
            else
            {
                throw new ExpiredException();
            }
        }
        else { throw new Exception(); }
    }

    public async Task<VerifyResult> VerifyRegisterAsync(VerifyCode dto)
    {
        if (dto.Phone is not null)
        {

            if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + dto.Phone, out UserCreateDto createDto))
            {
                if (_memoryCache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + dto.Phone, out VerificationDto verificationDto))
                {
                    if (verificationDto.Attempt >= VERIFICATION_MAXIMUM_ATTEMPTS)
                        throw new VerificationTooManyRequestsException();

                    else if (verificationDto.Code == dto.Code)
                    {
                        var user = _mapper.Map<User>(createDto);

                        var resultPassword = PasswordHasher.Hash(createDto.Password);
                        user.PasswordHash = resultPassword.Hash;
                        user.Salt = resultPassword.Salt;
                        user.CreatedAt = TimeHelper.GetDateTime();

                        var dResult = _userRepository.Update(user);
                        var result = await _userRepository.SaveAsync();

                        var token = await _tokenService.GenerateTokenAsync(user);


                        VerifyResult verifyResult = new VerifyResult()
                        {
                            Result = true,
                            Token = token
                        };
                        return verifyResult;
                    }
                    else
                    {
                        _memoryCache.Remove(VERIFY_REGISTER_CACHE_KEY + dto.Phone);
                        verificationDto.Attempt++;
                        _memoryCache.Set(VERIFY_REGISTER_CACHE_KEY + dto.Phone, verificationDto,
                            TimeSpan.FromMinutes(CACHED_FOR_MINUTS_VEFICATION));

                        VerifyResult verifyResult = new VerifyResult()
                        {
                            Result = false,
                            Token = string.Empty
                        };
                        return verifyResult;
                    }
                }
                else throw new VerificationCodeExpiredException();
            }
            else throw new ExpiredException();
        }
        else if (dto.Email is not null)
        {
            if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + dto.Email, out UserCreateDto userRegisterDto))
            {
                if (_memoryCache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + dto.Email, out VerificationDto verificationDto))
                {
                    if (verificationDto.Attempt >= VERIFICATION_MAXIMUM_ATTEMPTS)
                        throw new Exception();

                    else if (verificationDto.Code == dto.Code)
                    {
                        var password = userRegisterDto.Password;
                        var result = PasswordHasher.Hash(password);
                        var mappedUser = _mapper.Map<User>(userRegisterDto);
                        mappedUser.Salt = result.Salt;
                        mappedUser.PasswordHash = result.Hash;
                        mappedUser.CreatedAt = TimeHelper.GetDateTime();

                        var user = await _userRepository.AddAsync(mappedUser);
                        await _userRepository.SaveAsync();

                        var token = await _tokenService.GenerateTokenAsync(user);

                        VerifyResult verifyResult = new VerifyResult()
                        {
                            Result = true,
                            Token = token
                        };
                        return verifyResult;
                    }
                    else
                    {
                        _memoryCache.Remove(VERIFY_REGISTER_CACHE_KEY + dto.Email);
                        verificationDto.Attempt++;
                        _memoryCache.Set(VERIFY_REGISTER_CACHE_KEY + dto.Email, verificationDto,
                            TimeSpan.FromMinutes(CACHED_FOR_MINUTS_VEFICATION));

                        VerifyResult verifyResult = new VerifyResult()
                        {
                            Result = false,
                            Token = ""
                        };
                        return verifyResult;
                    }
                }
                else throw new VerificationCodeExpiredException();
            }
            else throw new ExpiredException();
        }
        else
            throw new Exception();
    }
}
