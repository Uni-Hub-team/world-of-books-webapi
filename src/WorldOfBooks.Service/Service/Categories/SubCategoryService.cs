using WorldOfBooks.Persistence.Dtos.Categories;

namespace WorldOfBooks.Service.Interfaces.Categories;

public class SubCategoryService : ICategoryService
{
    public Task<CategoryResultDto> CreateAsync(CategoryCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoryResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryResultDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryResultDto> UpdateAsync(long id, CategoryUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryResultDto> UpgradeStatusAsync(long id)
    {
        throw new NotImplementedException();
    }
}
