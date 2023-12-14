using WorldOfBooks.Persistence.Dtos.Books;

namespace WorldOfBooks.Service.Interfaces.Books;

public interface IBookStarService
{
    Task<BookStarResultDto> CreateAsync(BookStarCreationDto dto);
    Task<BookStarResultDto> UpdateAsync(long id, BookStarUpdateDto dto);
    Task<IEnumerable<BookStarResultDto>> GetByUserIdAsync(long userId);
    Task<IEnumerable<BookStarResultDto>> GetByBookIdAsync(long bookId);
    Task<IEnumerable<BookStarResultDto>> GetAllAsync();
}