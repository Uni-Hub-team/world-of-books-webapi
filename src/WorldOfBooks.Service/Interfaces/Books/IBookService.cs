using WorldOfBooks.Persistence.Dtos.Books;
using WorldOfBooks.Persistence.ViewModels.Books;

namespace WorldOfBooks.Service.Interfaces.Books;

public interface IBookService
{
    Task<BookResult> CreateAsync(BookCreateDto dto);
    Task<BookResult> UpdateAsync(long id, BookUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<BookResult> GetByIdAsync(long id);
    Task<IEnumerable<BookResult>> GetAllAsync();
}
