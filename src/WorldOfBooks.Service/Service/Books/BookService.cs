using AutoMapper;
using Microsoft.AspNetCore.Http;
using WorldOfBooks.Application.Exceptions.Authors;
using WorldOfBooks.DataAccess.IRepositories;
using WorldOfBooks.Domain.Entities.Books;
using WorldOfBooks.Domain.Entities.Users;
using WorldOfBooks.Persistence.Dtos.Books;
using WorldOfBooks.Persistence.ViewModels.Authors;
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

    private readonly string BOOKimg = "Books";
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
        var bookImage = await _fileService.UploadImageAsync(dto.Image, BOOKimg);
        var bookAudio = await _fileService.UploadAudioAsync(dto.Audio!, AUDIOS);
        var bookSource = await _fileService.UploadBookAsync(dto.Source, SOURCE);

        mappedBook.AudioPath = bookAudio;
        mappedBook.ImagePath = bookImage;
        mappedBook.SourcePath = bookSource;

        mappedBook.CreatedAt = TimeHelper.GetDateTime();

        await _bookRepository.AddAsync(mappedBook);
        await _bookRepository.SaveAsync();

        return _mapper.Map<BookResult>(mappedBook);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existBook = await _bookRepository.SelectAsync(author => author.Id.Equals(id))
           ?? throw new AuthorNotFoundException();

        var resultImg = await _fileService.DeleteImageAsync(existBook.ImagePath);
        var resultAudi = await _fileService.DeleteAudioAsync(existBook.AudioPath);
        var resultSource = await _fileService.DeleteBookAsync(existBook.SourcePath);


        _bookRepository.Delete(existBook);
        await _bookRepository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<BookResult>> GetAllAsync()
    {
        var existBook = _bookRepository.SelectAll();
        List<BookResult> emptyList = new  List<BookResult>();

        foreach (var book in existBook)
        {
            if (book.AudioPath  != null)
            {
                var result = _mapper.Map<BookResult>(book);
                result.Audio = true;
                emptyList.Add(result);
            }
        }
         return emptyList;
    }

    public async Task<BookResult> GetByIdAsync(long id)
    {
        var existBook = await _bookRepository.SelectAsync(book => book.Id.Equals(id))
          ?? throw new AuthorNotFoundException();
        if (existBook.AudioPath is not null)
        {
            var result =  _mapper.Map<BookResult>(existBook);
            result.Audio = true; 

            return result;
        }
        else
            return _mapper.Map<BookResult>(existBook);
    }

    public async Task<BookResult> UpdateAsync(long id, BookUpdateDto dto)
    {
        var existBook = await _bookRepository.SelectAsync(book => book.Id.Equals(id))
             ?? throw new AuthorNotFoundException();

        var mappedAuthor = _mapper.Map(dto, existBook);
        mappedAuthor.Id = id;
        mappedAuthor.UpdatedAt = TimeHelper.GetDateTime();

        _bookRepository.Update(mappedAuthor);
        await _bookRepository.SaveAsync();

        return _mapper.Map<BookResult>(mappedAuthor);
    }

    public async Task<BookResult> UpdateBookImageAsync(long BookId, IFormFile image)
    {
        var existBook = await _bookRepository.SelectAsync(book => book.Id.Equals(BookId))
            ?? throw new AuthorNotFoundException();

        if (image is not null)
        {
            var result = await _fileService.DeleteImageAsync(existBook.ImagePath);

            if (result)
            {
                var Img = await _fileService.UploadImageAsync(image!, BOOKimg);
                existBook.SourcePath = Img;
            }
        }

        existBook.UpdatedAt = TimeHelper.GetDateTime();
        _bookRepository.Update(existBook);
        await _bookRepository.SaveAsync();

        return _mapper.Map<BookResult>(existBook);
    }

    public async Task<BookResult> UpdateBookSourceAsync(long BookId, IFormFile source)
    {
        var existBook = await _bookRepository.SelectAsync(book => book.Id.Equals(BookId))
            ?? throw new AuthorNotFoundException();

        if (source is not null)
        {
            var result = await _fileService.DeleteBookAsync(existBook.SourcePath);

            if (result)
            {
                var sourceResult = await _fileService.UploadBookAsync(source!, SOURCE);
                existBook.SourcePath = sourceResult;
            }
        }

        existBook.UpdatedAt = TimeHelper.GetDateTime();
        _bookRepository.Update(existBook);
        await _bookRepository.SaveAsync();

        return _mapper.Map<BookResult>(existBook);
    }

    public async Task<BookResult> UpdateBookAudioAsync(long BookId, IFormFile audio)
    {
        var existBook = await _bookRepository.SelectAsync(book => book.Id.Equals(BookId))
            ?? throw new AuthorNotFoundException();

        if (audio is not null)
        {
            var result = await _fileService.DeleteAudioAsync(existBook.AudioPath);

            if (result)
            {
                var audioResult = await _fileService.UploadAudioAsync(audio, AUDIOS);
                existBook.AudioPath = audioResult;
            }
        }

        existBook.UpdatedAt = TimeHelper.GetDateTime();
        _bookRepository.Update(existBook);
        await _bookRepository.SaveAsync();

        return _mapper.Map<BookResult>(existBook);
    }

    public async Task<BookSourceResult> GetByIdSourceAsync(long id)
    {
        var existBook = await _bookRepository.SelectAsync(book => book.Id.Equals(id))
         ?? throw new AuthorNotFoundException();

        return _mapper.Map<BookSourceResult>(existBook);
    }

    public async Task<BookAudioResult> GetByIdAudioAsync(long id)
    {
        var existBook = await _bookRepository.SelectAsync(book => book.Id.Equals(id))
        ?? throw new AuthorNotFoundException();

        return _mapper.Map<BookAudioResult>(existBook);
    }
}
