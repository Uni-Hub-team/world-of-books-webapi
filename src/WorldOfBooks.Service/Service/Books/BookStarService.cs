using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldOfBooks.Application.Exceptions.Authors;
using WorldOfBooks.DataAccess.IRepositories;
using WorldOfBooks.Domain.Entities.Books;
using WorldOfBooks.Domain.Entities.Users;
using WorldOfBooks.Persistence.Dtos.Books;
using WorldOfBooks.Service.Interfaces.Books;

namespace WorldOfBooks.Service.Service.Books;

public class BookStarService : IBookStarService
{
    private readonly IMapper _mapper;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Book> _bookRepository;
    private readonly IRepository<BookStar> _bookStarRepository;
    public BookStarService(
        IMapper mapper,
        IRepository<User> userRepository,
        IRepository<Book> bookRepository,
        IRepository<BookStar> bookStarRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _bookRepository = bookRepository;
        _bookStarRepository = bookStarRepository;
    }

    public async Task<BookStarResultDto> CreateAsync(BookStarCreationDto dto)
    {
        var existUser = await _userRepository.SelectAsync(expression: user => user.Id.Equals(dto.UserId))
            ?? throw new AuthorNotFoundException();

        var existBook = await _bookRepository.SelectAsync(expression: book => book.Id.Equals(dto.BookId))
            ?? throw new AuthorNotFoundException();

        var mappedStar = _mapper.Map<BookStar>(dto);

        var result = await CountOfStarsInBookAsync(existBook.Id);
        mappedStar.AvverageStars = (result.Star + dto.Star)/(result.Count+1);
        await _bookStarRepository.AddAsync(mappedStar);
        await _bookStarRepository.SaveAsync();

        return _mapper.Map<BookStarResultDto>(mappedStar);
    }

    public async Task<BookStarResultDto> UpdateAsync(long id, BookStarUpdateDto dto)
    {
        var existStar = await _bookStarRepository.SelectAsync(star => star.Id.Equals(id))
            ?? throw new AuthorNotFoundException();

        var existUser = await _userRepository.SelectAsync(expression: user => user.Id.Equals(dto.UserId))
            ?? throw new AuthorNotFoundException();

        var existBook = await _bookRepository.SelectAsync(expression: book => book.Id.Equals(dto.BookId))
            ?? throw new AuthorNotFoundException();

        var mappedStar = _mapper.Map(dto, existStar);
        var result = await CountOfStarsInBookAsync(existBook.Id);
        mappedStar.AvverageStars = (result.Star + dto.Star) / (result.Count + 1);

        _bookStarRepository.Update(mappedStar);
        await _bookStarRepository.SaveAsync();

        return _mapper.Map<BookStarResultDto>(mappedStar);
    }

    public async Task<BookStarResultDto> GetByBookIdAsync(long bookId)
    {
        var existBook= await _bookRepository.SelectAsync(book => book.Id.Equals(bookId))
            ?? throw new AuthorNotFoundException();

        return _mapper.Map<BookStarResultDto>(existBook);
    }

    public Task<BookStarResultDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<BookStarResultDto> GetByUserIdAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BookStarResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    private async Task<(int Star, int Count)> CountOfStarsInBookAsync(long bookId)
    {
        var existBook = await _bookRepository.SelectAsync(expression: book => book.Id.Equals(bookId),
            includes: new[] { "BookStars" })
            ?? throw new AuthorNotFoundException();

        if (!existBook.BookStars.Any())
            return (Star: 0, Count: 0);

        int stars = 0;
        foreach(var  bookStar in existBook.BookStars)
        {
            stars += bookStar.Star;
        }

        return (stars, existBook.BookStars.Count);
    }
}