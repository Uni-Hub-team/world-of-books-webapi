using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorldOfBooks.Domain.Entities.Authors;
using WorldOfBooks.Domain.Entities.Books;
using WorldOfBooks.Domain.Entities.Categories;
using WorldOfBooks.Domain.Entities.Users;
using WorldOfBooks.Persistence.Dtos.Authors;
using WorldOfBooks.Persistence.Dtos.Books;
using WorldOfBooks.Persistence.Dtos.Categories;
using WorldOfBooks.Persistence.Dtos.Comments;
using WorldOfBooks.Persistence.Dtos.User;
using WorldOfBooks.Persistence.ViewModels.Authors;
using WorldOfBooks.Persistence.ViewModels.Books;
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

        CreateMap<Author, AuthorResult>().ReverseMap();
        CreateMap<Author, AuthorCreateDto>().ReverseMap();
        CreateMap<Author, AuthorUpdateDto>().ReverseMap();

        CreateMap<Book, BookResult>().ReverseMap();
        CreateMap<Book, BookAudioResult>().ReverseMap();
        CreateMap<Book, BookSourceResult>().ReverseMap();
        CreateMap<Book, BookCreateDto>().ReverseMap();
        CreateMap<Book, BookUpdateDto>().ReverseMap();

        CreateMap<Read, BookReadDto>().ReverseMap();
        CreateMap<Book, BookReadResult>().ReverseMap();

        CreateMap<Comment, CommentResultDto>().ReverseMap();
        CreateMap<Comment, CommentCreationDto>().ReverseMap();
    }
}
