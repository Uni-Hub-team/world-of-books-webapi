using AutoMapper;
using WorldOfBooks.Application.Exceptions.Authors;
using WorldOfBooks.DataAccess.IRepositories;
using WorldOfBooks.Domain.Entities.Books;
using WorldOfBooks.Persistence.Dtos.Books;
using WorldOfBooks.Persistence.ViewModels.Books;
using WorldOfBooks.Service.Commons.Helpers;
using WorldOfBooks.Service.Interfaces.Books;
using WorldOfBooks.Service.Interfaces.Common;

namespace WorldOfBooks.Service.Service.Books;

public class BookService : IBookService
{
    private IMapper _mapper;
    private IRepository<Book> _bookRepository;
    private IFileService _fileService;

    private readonly string BOOKS = "Books";
    private readonly string SOURCE = "Source";
    private readonly string AUDIOS = "Audios";

    public BookService(
        IMapper mapper,
        IRepository<Book> bookRepository,
        IFileService Service)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
        _fileService = Service;
    }
    public async Task<BookResult> CreateAsync(BookCreateDto dto)
    {
        var existBook = await _bookRepository.SelectAsync(book =>
        book.Title.ToLower().Equals(dto.Title.ToLower()));
        if (existBook is not null)
            throw new AuthorAlreadyExistsException();

        var mappedBook = _mapper.Map<Book>(dto);
        try
        {
        var bookSource = await _fileService.UploadBookAsync(dto.Source, SOURCE);

        }
        catch (Exception ex)
        {
            throw new Exception();
        }
        var bookImage = await _fileService.UploadImageAsync(dto.Image, BOOKS);
        var bookAudio = await _fileService.UploadAudioAsync(dto.Audio!, AUDIOS);

        mappedBook.AudioPath = bookAudio;
        mappedBook.ImagePath = bookImage;
       // mappedBook.SourcePath = bookSource;

        mappedBook.CreatedAt = TimeHelper.GetDateTime();

        await _bookRepository.AddAsync(mappedBook);
        await _bookRepository.SaveAsync();

        return _mapper.Map<BookResult>(mappedBook);
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<BookResult>> GetAllAsync()
    {
        var existAuthors = _bookRepository.SelectAll();

        return _mapper.Map<IEnumerable<BookResult>>(existAuthors);
    }

    public Task<BookResult> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<BookResult> UpdateAsync(long id, BookUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
