using AutoMapper;
using WorldOfBooks.Application.Exceptions.Categories;
using WorldOfBooks.DataAccess.IRepositories;
using WorldOfBooks.Domain.Entities.Categories;
using WorldOfBooks.Persistence.Dtos.Categories;
using WorldOfBooks.Service.Commons.Helpers;

namespace WorldOfBooks.Service.Interfaces.Categories;

public class SubCategoryService : ISubCategoryService
{
    private IMapper _mapper;
    private IRepository<Category> _categoryRepository;
    private IRepository<SubCategory> _subCategoryRepository;

    public SubCategoryService(
        IMapper mapper,
        IRepository<Category> categoryRepository,
        IRepository<SubCategory> cubCategoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
        _subCategoryRepository = cubCategoryRepository;
    }
    public async Task<SubCategoryResultDto> CreateAsync(SubCategoryCreateDto dto)
    {
        var existSubCategory = await _subCategoryRepository.SelectAsync(category =>
        category.Name.ToLower().Equals(dto.Name.ToLower()));
        if (existSubCategory is not null)
            throw new SubCategoryAlreadyExistsException();

        var existCategory = await _categoryRepository.SelectAsync(category => category.Id.Equals(dto.CategoryId))
          ?? throw new CategoryNotFoundException();

        var mappedSubCategory = _mapper.Map<SubCategory>(dto);
        mappedSubCategory.CreatedAt = TimeHelper.GetDateTime();

        await _subCategoryRepository.AddAsync(mappedSubCategory);
        await _subCategoryRepository.SaveAsync();

        return _mapper.Map<SubCategoryResultDto>(mappedSubCategory);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existSubCategory = await _subCategoryRepository.SelectAsync(device => device.Id.Equals(id))
          ?? throw new SubCategoryNotFoundException();

        _subCategoryRepository.Delete(existSubCategory);
        await _subCategoryRepository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<SubCategoryResultDto>> GetAllAsync()
    {
        var categories = _subCategoryRepository.SelectAll();

        return _mapper.Map<IEnumerable<SubCategoryResultDto>>(categories);
    }

    public async Task<SubCategoryResultDto> GetByIdAsync(long id)
    {
        var existSubCategory = await _subCategoryRepository.SelectAsync(subCategory => subCategory.Id.Equals(id))
          ?? throw new SubCategoryNotFoundException();

        return _mapper.Map<SubCategoryResultDto>(existSubCategory);
    }

    public async Task<SubCategoryResultDto> UpdateAsync(long id, SubCategoryUpdateDto dto)
    {
        var existSubCategory = await _subCategoryRepository.SelectAsync(subCategory => subCategory.Id.Equals(id))
            ?? throw new CategoryNotFoundException();

        var existCategory = await _categoryRepository.SelectAsync(category => category.Id.Equals(dto.CategoryId))
          ?? throw new CategoryNotFoundException();

        var mappedSubCategory = _mapper.Map(dto, existSubCategory);
        mappedSubCategory.Id = id;
        mappedSubCategory.UpdatedAt = TimeHelper.GetDateTime();

        _subCategoryRepository.Update(mappedSubCategory);
        await _subCategoryRepository.SaveAsync();

        return _mapper.Map<SubCategoryResultDto>(mappedSubCategory);
    }
}
