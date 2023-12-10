using AutoMapper;
using WorldOfBooks.Domain.Entities.Categories;
using WorldOfBooks.Domain.Entities.Users;
using WorldOfBooks.Persistence.Dtos.Categories;
using WorldOfBooks.Persistence.Dtos.User;
using WorldOfBooks.Persistence.ViewModels.User;

namespace WorldOfBooks.Service.Mappers;

public class MappingData : Profile
{
    public MappingData()
    {
        //Users
        CreateMap<User, UserUpdateDto>().ReverseMap();
        CreateMap<User, UserCreateDto>().ReverseMap();
        CreateMap<User, UserResultDto>().ReverseMap();

        CreateMap<Category, CategoryResultDto>().ReverseMap();
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();

        CreateMap<SubCategory, SubCategoryResultDto>().ReverseMap();
        CreateMap<SubCategory, SubCategoryCreateDto>().ReverseMap();
        CreateMap<SubCategory, SubCategoryUpdateDto>().ReverseMap();
    }
}
