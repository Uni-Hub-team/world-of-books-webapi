using Microsoft.AspNetCore.Http;
using WorldOfBooks.Persistence.Dtos.Books;
using WorldOfBooks.Persistence.ViewModels.Books;

namespace WorldOfBooks.Service.Interfaces.Books;

public interface IBookService
{
    Task<BookResult> CreateAsync(BookCreateDto dto);
    Task<BookResult> UpdateAsync(long id, BookUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<BookResult>> GetAllAsync();
    Task<BookResult> UpdateBookImageAsync(long BookId, IFormFile image);
    Task<BookResult> UpdateBookSourceAsync(long BookId, IFormFile source);
    Task<BookResult> UpdateBookAudioAsync(long BookId, IFormFile audio);
    Task<BookResult> GetByIdAsync(long id);
    Task<BookSourceResult> GetByIdSourceAsync(long id);
    Task<BookAudioResult> GetByIdAudioAsync(long id);
}
