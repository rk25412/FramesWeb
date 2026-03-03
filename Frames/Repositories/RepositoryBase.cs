using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Frames.Repositories;

public class RepositoryBase<T>(AppDbContext dbContext) : IRepositoryBase<T> where T : EntityBase
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

    public void Update(T entity)
    {
        dbContext.Set<T>().Attach(entity);
        entity.ModifiedDate = DateTime.Now;
        dbContext.Entry(entity).State = EntityState.Modified;
        dbContext.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
    }

    public void Delete(T entity) => dbContext.Set<T>().Remove(entity);

    public void DeleteByCondition(Expression<Func<T, bool>> expression) =>
        dbContext.Set<T>().Where(expression).ExecuteDelete();
}