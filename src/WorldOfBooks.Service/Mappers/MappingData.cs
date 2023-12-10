using AutoMapper;
using WorldOfBooks.Domain.Entities.Users;
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
    }
}
