using WorldOfBooks.Persistence.Dtos.Authors;
using WorldOfBooks.Persistence.ViewModels.Authors;

namespace WorldOfBooks.Service.Interfaces.Authors;

public interface IAuthorService
{
    Task<AuthorResult> CreateAsync(AuthorCreateDto dto);
    Task<AuthorResult> UpdateAsync(long id, AuthorUpdateDto dto);
    Task<AuthorResult> UpdateImageAsync(long id, AuthorImageUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<AuthorResult> GetByIdAsync(long id);
    Task<IEnumerable<AuthorResult>> GetAllAsync();
}
