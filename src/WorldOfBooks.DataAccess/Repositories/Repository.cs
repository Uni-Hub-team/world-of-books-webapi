using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using WorldOfBooks.DataAccess.Contexts;
using WorldOfBooks.DataAccess.IRepositories;
using WorldOfBooks.Domain.Commons;

namespace WorldOfBooks.DataAccess.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly DbSet<TEntity> _dbSet;
    private readonly WorldOfBooksDbContext _dbContext;
    public Repository(WorldOfBooksDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        EntityEntry<TEntity> entry = await _dbSet.AddAsync(entity);
            
        return entry.Entity;
    }

    public void Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Destroy(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveAsync()
        => await _dbContext.SaveChangesAsync() >= 0;

    public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null!, bool isTracking = false, string[] includes = null!)
    {
        throw new NotImplementedException();
    }

    public async Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null!)
    {
        IQueryable<TEntity> entities = expression == null ? _dbSet.AsQueryable() : _dbSet.Where(expression).AsQueryable();

        if (includes is not null)
            foreach (var include in includes)
                entities = entities.Include(include);

        return await entities.FirstOrDefaultAsync();
    }

    public TEntity Update(TEntity entity)
    {
        EntityEntry<TEntity> entry = _dbContext.Update(entity);

        return entry.Entity;
    }
}
