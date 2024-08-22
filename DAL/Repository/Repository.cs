using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository;

public class Repository<TEntity>(DbContext dbContext) : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DbContext dbContext = dbContext;

    public async Task<TEntity?> GetById(long id) => await dbContext.Set<TEntity>().FindAsync(id);

    public async Task<long> AddAsync(TEntity entity)
    {
        await dbContext.Set<TEntity>().AddAsync(entity);
        await dbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<long> UpdateAsync(TEntity entity)
    {
        dbContext.Entry(entity).State = EntityState.Modified;
        return await dbContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await GetById(id);
        if (entity is null)
            return false;

        dbContext.Remove(entity);

        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<List<TEntity>> GetWithFilterAsync(Expression<Func<TEntity, bool>> predicate) =>
        await dbContext.Set<TEntity>().Where(predicate).ToListAsync();
}