
using System.Linq.Expressions;

using DAL.Entities;

namespace DAL.Repository.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetById(long id);
    Task<long> AddAsync(TEntity entity);
    Task<long> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(long id);
    Task<List<TEntity>> GetWithFilterAsync(Expression<Func<TEntity, bool>> predicate);
}