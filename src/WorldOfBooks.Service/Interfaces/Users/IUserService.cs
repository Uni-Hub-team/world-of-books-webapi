using WorldOfBooks.Domain.Enums;
using WorldOfBooks.Persistence.Dtos.RoleDto;
using WorldOfBooks.Persistence.Dtos.User;
using WorldOfBooks.Persistence.ViewModels.User;

namespace WorldOfBooks.Service.Interfaces.User;

public interface IUserService
{
    Task<UserResultDto> UpdateAsync(long id, UserUpdateDto dto);
    Task<UserResultDto> UpgradeRoleAsync(long id, UserRoleUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<UserResultDto> GetByIdAsync(long id);
    Task<IEnumerable<UserResultDto>> GetByRoleAsync(Role role);
    Task<UserResultDto> UpdateSecurityAsync(long id, UserSecurityUpdateDto security);
    Task<IEnumerable<UserResultDto>> GetAllAsync();
    //Task<IEnumerable<UserResultDto>> GetAllAsync(PaginationParams pagination, string search = null);
}
