using WorldOfBooks.Persistence.Dtos.Books;

namespace WorldOfBooks.Service.Interfaces.Books;

public interface IBookStarService
{
    Task<BookStarResultDto> CreateAsync(BookStarCreationDto dto);
    Task<BookStarResultDto> UpdateAsync(long id, BookStarUpdateDto dto);
    Task<BookStarResultDto> GetByIdAsync(long id);
    Task<BookStarResultDto> GetByBookIdAsync(long bookId);
    Task<BookStarResultDto> GetByUserIdAsync(long userId);
    Task<IEnumerable<BookStarResultDto>> GetAllAsync();
}