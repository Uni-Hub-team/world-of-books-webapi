using System.Threading.Tasks;
using WorldOfBooks.Persistence.Dtos.Books;
using WorldOfBooks.Persistence.ViewModels.Books;

namespace WorldOfBooks.Service.Interfaces.Books;

public interface IBookReadService
{
    Task<BookReadResult> CreateAsync(long UserId, BookReadDto dto);
    Task<BookReadResult> GetByUserIdAsync(long id);
    Task<BookReadResult> GetByBookIdAsync(long id);
}
