using AutoMapper;
using Microsoft.AspNetCore.Http;
using WorldOfBooks.Application.Exceptions.Authors;
using WorldOfBooks.DataAccess.IRepositories;
using WorldOfBooks.Domain.Entities.Authors;
using WorldOfBooks.Persistence.Dtos.Authors;
using WorldOfBooks.Persistence.ViewModels.Authors;
using WorldOfBooks.Service.Commons.Helpers;
using WorldOfBooks.Service.Interfaces.Authors;
using WorldOfBooks.Service.Interfaces.Common;

namespace WorldOfBooks.Service.Service.Authors;

public class AuthorService : IAuthorService
{
    private IFileService _fileService;
    private IMapper _mapper;
    private IRepository<Author> _authorRepository;

    private readonly string USERS = "Users";

    public AuthorService(
        IMapper mapper,
        IRepository<Author> authorRepository,
        IFileService Service)
    {
        _fileService = Service;
        _mapper = mapper;
        _authorRepository = authorRepository;
    }
    public async Task<AuthorResult> CreateAsync(AuthorCreateDto dto)
    {
        var existAuthor = await _authorRepository.SelectAsync(author =>
        author.FullName.ToLower().Equals(dto.FullName.ToLower()));
        if (existAuthor is not null)
            throw new AuthorAlreadyExistsException();

        var mappedAuthor = _mapper.Map<Author>(dto);

        var Img = await _fileService.UploadImageAsync(dto.Images, USERS);
        mappedAuthor.ImagePath = Img;
        mappedAuthor.CreatedAt = TimeHelper.GetDateTime();

        await _authorRepository.AddAsync(mappedAuthor);
        await _authorRepository.SaveAsync();

        return _mapper.Map<AuthorResult>(mappedAuthor);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existAuthor = await _authorRepository.SelectAsync(author => author.Id.Equals(id))
          ?? throw new AuthorNotFoundException();

        var result = await _fileService.DeleteImageAsync(existAuthor.ImagePath);

        if (!result)
            throw new Exception();

        _authorRepository.Delete(existAuthor);
        await _authorRepository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<AuthorResult>> GetAllAsync()
    {
        var existAuthors = _authorRepository.SelectAll();

        return _mapper.Map<IEnumerable<AuthorResult>>(existAuthors);
    }

    public async Task<AuthorResult> GetByIdAsync(long id)
    {
        var existAuthor = await _authorRepository.SelectAsync(author => author.Id.Equals(id))
          ?? throw new AuthorNotFoundException();

        return _mapper.Map<AuthorResult>(existAuthor);
    }

    public async Task<AuthorResult> UpdateAsync(long id, AuthorUpdateDto dto)
    {
        var existAuthor = await _authorRepository.SelectAsync(author => author.Id.Equals(id))
             ?? throw new AuthorNotFoundException();

        var mappedAuthor = _mapper.Map(dto, existAuthor);
        mappedAuthor.Id = id;
        mappedAuthor.UpdatedAt = TimeHelper.GetDateTime();

        _authorRepository.Update(mappedAuthor);
        await _authorRepository.SaveAsync();

        return _mapper.Map<AuthorResult>(mappedAuthor);
    }

    public async Task<AuthorResult> UpdateImageAsync(long id, AuthorImageUpdateDto dto)
    {
        var existAuthor = await _authorRepository.SelectAsync(category => category.Id.Equals(id))
            ?? throw new AuthorNotFoundException();

        var result = await _fileService.DeleteImageAsync(existAuthor.ImagePath);

        if (result)
        {
            var img = await _fileService.UploadImageAsync(dto.Images, USERS);
            existAuthor.ImagePath = img;
            existAuthor.UpdatedAt = TimeHelper.GetDateTime();
        }
        else
            throw new Exception();

        _authorRepository.Update(existAuthor);
        await _authorRepository.SaveAsync();

        return _mapper.Map<AuthorResult>(existAuthor);
    }
}
