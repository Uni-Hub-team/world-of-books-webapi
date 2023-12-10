using WorldOfBooks.Persistence.Dtos.Categories;

namespace WorldOfBooks.Service.Interfaces.Categories;

public interface ISubCategoryService
{
    Task<SubCategoryResultDto> CreateAsync(SubCategoryCreateDto dto);
    Task<SubCategoryResultDto> UpdateAsync(long id, SubCategoryUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<SubCategoryResultDto> GetByIdAsync(long id);
    Task<IEnumerable<SubCategoryResultDto>> GetAllAsync();
}
