using WorldOfBooks.Persistence.Dtos.Authors;
using WorldOfBooks.Persistence.ViewModels.Authors;
using WorldOfBooks.Service.Interfaces.Authors;

namespace WorldOfBooks.Service.Service.Authors;

public class AuthorService : IAuthorService
{
    public Task<AuthorResult> CreateAsync(AuthorCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AuthorResult>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AuthorResult> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<AuthorResult> UpdateAsync(long id, AuthorUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
