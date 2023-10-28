using System.Linq.Expressions;

namespace BankDeposits.Domain.Services.Interfaces;

public interface IService<TEntity> where TEntity: class
{
    Task<TEntity> GetAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(Guid id);
}