using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorldOfBooks.Application.Exceptions.Auth;
using WorldOfBooks.Application.Exceptions.Users;
using WorldOfBooks.DataAccess.IRepositories;
using WorldOfBooks.Domain.Configurations;
using WorldOfBooks.Domain.Entities.Users;
using WorldOfBooks.Domain.Enums;
using WorldOfBooks.Persistence.Dtos.User;
using WorldOfBooks.Persistence.ViewModels.User;
using WorldOfBooks.Service.Commons.Helpers;
using WorldOfBooks.Service.Commons.Security;
using WorldOfBooks.Service.Extensions;
using WorldOfBooks.Service.Interfaces.User;

namespace WorldOfBooks.Service.Service.Users;

public class UserService : IUserService
{
    private IMapper _mapper;
    private IRepository<User> _userRepository;

    public UserService(IMapper mapper, IRepository<User> userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;

    }
    public async Task<bool> DeleteAsync(long id)
    {
        var existUser = await _userRepository.SelectAsync(user => user.Id.Equals(id))
           ?? throw new UserNotFoundException();

        _userRepository.Delete(existUser);
        await _userRepository.SaveAsync();
        return true;
    }

    public Task<IEnumerable<UserResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserResultDto>> GetAllAsync(PaginationParams pagination, string search = null)
    {
        var users = _userRepository.SelectAll();
        if (!string.IsNullOrEmpty(search))
        {
            users = users.Where(user =>
                user.FirstName.ToLower().Contains(search.ToLower()) ||
                user.LastName.ToLower().Contains(search.ToLower())
            );
        }

        var result = users.ToPagedList(pagination);
        return _mapper.Map<IEnumerable<UserResultDto>>(result);
    }

    public async Task<UserResultDto> GetByIdAsync(long id)
    {
        var existUser = await _userRepository.SelectAsync(user => user.Id.Equals(id))
           ?? throw new UserNotFoundException();

        return _mapper.Map<UserResultDto>(existUser);
    }

    public async Task<IEnumerable<UserResultDto>> GetByRoleAsync(Role role)
    {
        var users = await _userRepository.SelectAll(user => user.Role.Equals(role)).ToListAsync();
        if (!users.Any())
            throw new UserNotFoundException();

        return _mapper.Map<IEnumerable<UserResultDto>>(users);
    }

    public async Task<UserResultDto> UpdateAsync(long id, UserUpdateDto dto)
    {
        var existUser = await _userRepository.SelectAsync(user => user.Id.Equals(id))
            ?? throw new UserNotFoundException();

        var checkUser = await _userRepository.SelectAsync(user => user.Phone.Equals(dto.Phone) &&
        !user.Phone.Equals(existUser.Phone));

        if (checkUser is not null)
            throw new UserAlreadyExistsException();

        var mappedUser = _mapper.Map(dto, existUser);
        mappedUser.Id = id;
        mappedUser.Role = existUser.Role;
        mappedUser.UpdatedAt = TimeHelper.GetDateTime();

        _userRepository.Update(mappedUser);
        await _userRepository.SaveAsync();

        return _mapper.Map<UserResultDto>(mappedUser);
    }

    public async Task<UserResultDto> UpdateSecurityAsync(long id, UserSecurityUpdateDto security)
    {
        var existUser = await _userRepository.SelectAsync(user => user.Id.Equals(id))
            ?? throw new UserNotFoundException();

        if (security.NewPassword != security.ConfirmPassword)
            throw new PasswordNotMatchException();

        var passwords = PasswordHasher.Hash(security.NewPassword);
        existUser.PasswordHash = passwords.Hash;
        existUser.Salt = passwords.Salt;
        existUser.UpdatedAt = TimeHelper.GetDateTime();

        _userRepository.Update(existUser);
        await _userRepository.SaveAsync();

        return _mapper.Map<UserResultDto>(existUser);
    }

    public async Task<UserResultDto> UpgradeRoleAsync(long id, Role role)
    {
        var existUser = await _userRepository.SelectAsync(u => u.Id.Equals(id))
             ?? throw new UserNotFoundException();

        existUser.Id = id;
        existUser.Role = role;
        existUser.UpdatedAt = TimeHelper.GetDateTime();

        _userRepository.Update(existUser);
        await _userRepository.SaveAsync();

        return _mapper.Map<UserResultDto>(existUser);
    }
}
