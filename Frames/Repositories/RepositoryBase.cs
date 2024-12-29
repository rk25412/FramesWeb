using System.Linq.Expressions;
using Frames.Contracts.Repositories;
using Frames.Data;
using Microsoft.EntityFrameworkCore;

namespace Frames.Repositories;

public class RepositoryBase<T>(AppDbContext dbContext) : IRepositoryBase<T> where T : class
{
    public IQueryable<T> FindAll(bool trackChanges) => !trackChanges
        ? dbContext.Set<T>().AsNoTracking() 
        : dbContext.Set<T>();

    public IQueryable<T> FindByCondition(
        Expression<Func<T, bool>> expression, 
        bool trackChanges) => !trackChanges
            ? dbContext.Set<T>().Where(expression).AsNoTracking() 
            : dbContext.Set<T>().Where(expression);

    public void Create(T entity) => dbContext.Set<T>().Add(entity);
    public void Update(T entity) => dbContext.Set<T>().Update(entity);
    public void Delete(T entity) => dbContext.Set<T>().Remove(entity);
}