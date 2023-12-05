using Microsoft.AspNetCore.Mvc.ApplicationModels;
using WorldOfBooks.DataAccess.IRepositories;
using WorldOfBooks.DataAccess.Repositories;
using WorldOfBooks.Service.Interfaces.Auth;
using WorldOfBooks.Service.Mappers;
using WorldOfBooks.Service.Service.Auth;
using WorldOfBooks.WebApi.Middleware;

namespace WorldOfBooks.WebApi.Extensions;


public static class ServiceExtensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {

        services.AddControllers(options =>
        options.Conventions.Add(new RouteTokenTransformerConvention(new SlugParameterTransformer())));
        //Auto mapping Dependency Injection
        services.AddAutoMapper(typeof(MappingData));


        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddHttpContextAccessor();

        #region Services


        //Auth
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        #endregion
    }
}