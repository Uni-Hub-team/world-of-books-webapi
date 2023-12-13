using WorldOfBooks.Domain.Configurations;
using WorldOfBooks.Persistence.Dtos.Comments;

namespace WorldOfBooks.Service.Interfaces.Books;

public interface ICommentService
{
    Task<CommentResultDto> CreateAsync(CommentCreationDto dto);
    Task<bool> DeleteAsync(long id);
    Task<CommentResultDto> GetByIdAsync(long id);
    Task<IEnumerable<CommentResultDto>> GetByBookIdsync(long bookId);
}