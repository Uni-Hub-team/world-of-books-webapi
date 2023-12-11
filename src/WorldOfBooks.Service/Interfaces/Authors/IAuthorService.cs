using WorldOfBooks.Domain.Configurations;
using WorldOfBooks.Domain.Enums;
using WorldOfBooks.Persistence.Dtos.Authors;
using WorldOfBooks.Persistence.Dtos.RoleDto;
using WorldOfBooks.Persistence.Dtos.User;
using WorldOfBooks.Persistence.ViewModels.Authors;
using WorldOfBooks.Persistence.ViewModels.User;

namespace WorldOfBooks.Service.Interfaces.Authors;

public interface IAuthorService
{
    Task<AuthorResult> CreateAsync(AuthorCreateDto dto);
    Task<AuthorResult> UpdateAsync(long id, AuthorUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<AuthorResult> GetByIdAsync(long id);
    Task<IEnumerable<AuthorResult>> GetAllAsync();
}
