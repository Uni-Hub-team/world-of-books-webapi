using AutoMapper;
using WorldOfBooks.Application.Exceptions.Categories;
using WorldOfBooks.Application.Exceptions.Users;
using WorldOfBooks.DataAccess.IRepositories;
using WorldOfBooks.Domain.Entities.Categories;
using WorldOfBooks.Domain.Enums;
using WorldOfBooks.Persistence.Dtos.Categories;
using WorldOfBooks.Persistence.ViewModels.User;
using WorldOfBooks.Service.Commons.Helpers;

namespace WorldOfBooks.Service.Interfaces.Categories;

public class CategoryService : ICategoryService
{
    private IMapper _mapper;
    private IRepository<Category> _categoryRepository;

    public CategoryService(IMapper mapper, IRepository<Category> userRepository)
    {
        _mapper = mapper;
        _categoryRepository = userRepository;

    }
    public async Task<CategoryResultDto> CreateAsync(CategoryCreateDto dto)
    {
        var existCategory = await _categoryRepository.SelectAsync(category =>
        category.Name.ToLower().Equals(dto.Name.ToLower()));
        if (existCategory is not null)
            throw new CategoryAlreadyExistsException();

        var mappedCategory= _mapper.Map<Category>(dto);
        mappedCategory.CreatedAt = TimeHelper.GetDateTime();

        await _categoryRepository.AddAsync(mappedCategory);
        await _categoryRepository.SaveAsync();

        return _mapper.Map<CategoryResultDto>(mappedCategory);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existDevice = await _categoryRepository.SelectAsync(device => device.Id.Equals(id))
           ?? throw new CategoryNotFoundException();

        _categoryRepository.Delete(existDevice);
        await _categoryRepository.SaveAsync();
        return true;
    }

    public async Task<IEnumerable<CategoryResultDto>> GetAllAsync()
    {
        var categories =  _categoryRepository.SelectAll();

        return _mapper.Map<IEnumerable<CategoryResultDto>>(categories);
    }

    public async Task<CategoryResultDto> GetByIdAsync(long id)
    {
        var existCategory = await _categoryRepository.SelectAsync(category => category.Id.Equals(id))
           ?? throw new UserNotFoundException();

        return _mapper.Map<CategoryResultDto>(existCategory);
    }

    public async Task<CategoryResultDto> UpdateAsync(long id, CategoryUpdateDto dto)
    {
        var existCategory = await _categoryRepository.SelectAsync(user => user.Id.Equals(id))
            ?? throw new UserNotFoundException();

        var mappedCategory = _mapper.Map(dto, existCategory);
        mappedCategory.Id = id;
        mappedCategory.UpdatedAt = TimeHelper.GetDateTime();

        _categoryRepository.Update(mappedCategory);
        await _categoryRepository.SaveAsync();

        return _mapper.Map<CategoryResultDto>(mappedCategory);
    }

    public async Task<CategoryResultDto> UpgradeStatusAsync(long id, Status status)
    {
        var existCategory = await _categoryRepository.SelectAsync(user => user.Id.Equals(id))
            ?? throw new UserNotFoundException();

        existCategory.Id = id;
        existCategory.status = status;
        existCategory.UpdatedAt = TimeHelper.GetDateTime();

        _categoryRepository.Update(existCategory);
        await _categoryRepository.SaveAsync();

        return _mapper.Map<CategoryResultDto>(existCategory);
    }
}