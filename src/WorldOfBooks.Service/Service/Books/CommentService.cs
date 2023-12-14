using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorldOfBooks.Application.Exceptions.Authors;
using WorldOfBooks.DataAccess.IRepositories;
using WorldOfBooks.Domain.Entities.Books;
using WorldOfBooks.Domain.Entities.Users;
using WorldOfBooks.Persistence.Dtos.Comments;
using WorldOfBooks.Service.Interfaces.Books;

namespace WorldOfBooks.Service.Service.Books;

public class CommentService : ICommentService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Book> _bookRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Comment> _commentRepository;
    public CommentService(
        IMapper mapper,
        IRepository<Book> bookRepository,
        IRepository<User> userRepository,
        IRepository<Comment> commentRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
        _userRepository = userRepository;
        _commentRepository = commentRepository;
    }

    public async Task<CommentResultDto> CreateAsync(CommentCreationDto dto)
    {
        var existBook = await _bookRepository.SelectAsync(book => book.Id.Equals(dto.BookId))
            ?? throw new AuthorNotFoundException();

        var existUser = await _userRepository.SelectAsync(user => user.Id.Equals(dto.UserId))
            ?? throw new AuthorNotFoundException();

        var mappedComment = _mapper.Map<Comment>(dto);
        mappedComment.Book = existBook;
        mappedComment.User = existUser;
        await _commentRepository.AddAsync(mappedComment);
        await _commentRepository.SaveAsync();

        return _mapper.Map<CommentResultDto>(mappedComment);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existComment = await _commentRepository.SelectAsync(comment => comment.Id == id)
            ?? throw new AuthorNotFoundException();

        _commentRepository.Destroy(existComment);
        return true;
    }

    public async Task<CommentResultDto> GetByIdAsync(long id)
    {
        var existComment = await _commentRepository.SelectAsync(comment => comment.Id == id)
            ?? throw new AuthorNotFoundException();

        return _mapper.Map<CommentResultDto>(existComment);
    }

    public async Task<IEnumerable<CommentResultDto>> GetByBookIdsync(long bookId)
    {
        var comments = await _commentRepository
            .SelectAll(comment => comment.BookId.Equals(bookId)).ToListAsync();

        return _mapper.Map<IEnumerable<CommentResultDto>>(comments);
    }
}