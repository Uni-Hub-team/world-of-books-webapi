using AutoMapper;
using WorldOfBooks.Application.Exceptions.Categories;
using WorldOfBooks.Application.Exceptions.Users;
using WorldOfBooks.DataAccess.IRepositories;
using WorldOfBooks.Domain.Entities.Categories;
using WorldOfBooks.Domain.Enums;
using WorldOfBooks.Persistence.Dtos.Categories;
using WorldOfBooks.Service.Commons.Helpers;

namespace WorldOfBooks.Service.Interfaces.Categories;

public class SubCategoryService : ISubCategoryService
{
    public Task<SubCategoryResultDto> CreateAsync(SubCategoryCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SubCategoryResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<SubCategoryResultDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<SubCategoryResultDto> UpdateAsync(long id, SubCategoryUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
