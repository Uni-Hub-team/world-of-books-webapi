﻿using System.Linq.Expressions;
using WorldOfBooks.Domain.Commons;

namespace WorldOfBooks.DataAccess.IRepositories;

public interface IRepository<TEntity> where TEntity : Auditable
{
    Task<TEntity> AddAsync(TEntity entity);
    TEntity Update(TEntity entity);
    void Delete(TEntity entity);
    void Destroy(TEntity entity);
    Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null!);
    IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null!,
        bool isTracking = false,
        string[] includes = null!);
    Task<bool> SaveAsync();
}