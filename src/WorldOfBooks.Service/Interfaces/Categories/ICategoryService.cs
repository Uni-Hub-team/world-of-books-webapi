using WorldOfBooks.Persistence.Dtos.Categories;
namespace WorldOfBooks.Service.Interfaces.Categories;

public interface ICategoryService
{
    Task<CategoryResultDto> CreateAsync(CategoryCreateDto dto);
    Task<CategoryResultDto> UpdateAsync(long id, CategoryUpdateDto dto);
    Task<CategoryResultDto> UpgradeStatusAsync(long id);
    Task<bool> DeleteAsync(long id);
    Task<CategoryResultDto> GetByIdAsync(long id);
    Task<IEnumerable<CategoryResultDto>> GetAllAsync();
}