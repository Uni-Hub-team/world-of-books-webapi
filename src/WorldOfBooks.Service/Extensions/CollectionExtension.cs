
using Newtonsoft.Json;
using WorldOfBooks.Domain.Commons;
using WorldOfBooks.Domain.Configurations;
using WorldOfBooks.Service.Commons.Helpers;

namespace WorldOfBooks.Service.Extensions;

public static class CollectionExtension
{
    public static IEnumerable<TEntity> ToPagedList<TEntity>(this IQueryable<TEntity> entities, PaginationParams pagination)
        where TEntity : Auditable
    {
        if (pagination.PageSize == 0 && pagination.PageIndex == 0)
        {
            pagination = new PaginationParams()
            {
                PageSize = 25,
                PageIndex = 1
            };
        }
        var metaData = new PaginationMetaData(entities.Count(), pagination);

        var json = JsonConvert.SerializeObject(metaData);

        if (HttpContextHelper.ResponseHeaders != null)
        {
            if (HttpContextHelper.ResponseHeaders.ContainsKey("X-Pagination"))
                HttpContextHelper.ResponseHeaders.Remove("X-Pagination");

            HttpContextHelper.ResponseHeaders.Add("X-Pagination", json);
        }

        if (pagination.PageIndex <= 0 || pagination.PageSize <= 0)
            throw new Exception();

        return entities.OrderBy(e => e.Id)
            .Skip((pagination.PageIndex - 1) * pagination.PageSize)
            .Take(pagination.PageSize);
    }
}
