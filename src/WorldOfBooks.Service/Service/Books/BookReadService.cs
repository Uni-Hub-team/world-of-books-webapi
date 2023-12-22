using AutoMapper;
using WorldOfBooks.DataAccess.IRepositories;
using WorldOfBooks.Domain.Entities.Books;
using WorldOfBooks.Persistence.Dtos.Books;
using WorldOfBooks.Service.Commons.Helpers;
using WorldOfBooks.Service.Interfaces.Books;

namespace WorldOfBooks.Service.Service.Books;

public class BookReadService : IBookReadService
{
    private IMapper _mapper;
    private IRepository<Read> _readRepository;

    public BookReadService(
        IMapper mapper,
        IRepository<Read> read)
    {
        _mapper = mapper;
        _readRepository = read;
    }
    public async Task<BookReadResult> CreateAsync(long UserId, BookReadDto dto)
    {
        var mappedRead = _mapper.Map<Read>(dto);
        mappedRead.UserId = UserId;
        mappedRead.CreatedAt = TimeHelper.GetDateTime();

        await _readRepository.AddAsync(mappedRead);
        await _readRepository.SaveAsync();

        return _mapper.Map<BookReadResult>(mappedRead);
    }

    public async Task<BookReadResult> GetByBookIdAsync(long id)
    {
        var existAuthors = _readRepository.SelectAll();

        var result = _mapper.Map<BookReadResult>(existAuthors);
        result.Count = existAuthors.Count();

        return result;
    }

    public Task<BookReadResult> GetByUserIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
