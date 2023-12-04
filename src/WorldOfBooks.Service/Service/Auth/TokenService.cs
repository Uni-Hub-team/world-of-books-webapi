using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WorldOfBooks.Application.Exceptions.Users;
using WorldOfBooks.DataAccess.IRepositories;
using WorldOfBooks.Domain.Entities.Users;
using WorldOfBooks.Service.Commons.Helpers;
using WorldOfBooks.Service.Interfaces.Auth;

namespace WorldOfBooks.Service.Service.Auth;

public class TokenService : ITokenService
{
    private IConfiguration _configuration;
    private readonly IRepository<User> _userRepository;
    public TokenService(IConfiguration configuration, IRepository<User> userRepository)
    {
        _configuration = configuration.GetSection("Jwt");
        _userRepository = userRepository;
    }

    public async Task<string> GenerateTokenAsync(User user)
    {
        var existUser = await _userRepository.SelectAsync(user => user.Id.Equals(user.Id))
            ?? throw new UserNotFoundException();

        var identityClaims = new Claim[]
        {
            new Claim ("Id", user.Id.ToString()),
            new Claim ("FirstName", user.FirstName),
            new Claim ("LastName", user.LastName),
            new Claim ("Phone", user.Phone),
            new Claim ("Email", user.Email),
            new Claim (ClaimTypes.Role, user.Role.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
        var keyCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        int expiresHours = 24;

        var token = new JwtSecurityToken(
            issuer: _configuration["Issuer"],
            audience: _configuration["Audience"],
            claims: identityClaims,
            expires: TimeHelper.GetDateTime().AddHours(expiresHours),
            signingCredentials: keyCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}