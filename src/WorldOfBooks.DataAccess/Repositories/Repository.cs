using System.Linq.Expressions;
using WorldOfBooks.DataAccess.IRepositories;
using WorldOfBooks.Domain.Commons;

namespace WorldOfBooks.DataAccess.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    public Task<TEntity> AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Destroy(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveAsync()
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, bool isTracking = false, string[] includes = null)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
    {
        throw new NotImplementedException();
    }

    public TEntity Update(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
