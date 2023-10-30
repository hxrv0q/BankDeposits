using BankDeposits.Domain.Database;
using BankDeposits.Domain.Exceptions;
using BankDeposits.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BankDeposits.Domain.Services;

public class GenericService<TEntity> : IService<TEntity>
    where TEntity : class
{
    private readonly AppDbContext _context;

    protected GenericService(AppDbContext context) => _context = context;

    protected DbSet<TEntity> Set => _context.Set<TEntity>();

    public async virtual Task<IEnumerable<TEntity>> GetAllAsync() => await Set.ToListAsync();

    public async virtual Task<TEntity> GetAsync(Guid id) => await Set.FindAsync(id) ?? throw new EntityNotFoundException(typeof(TEntity).Name);

    public async virtual Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate) => await Set.Where(predicate).FirstOrDefaultAsync();

    public async virtual Task<TEntity> AddAsync(TEntity entity)
    {
        var entry = _context.Entry(entity);
        if (entry.State == EntityState.Detached)
        {
            Set.Add(entity);
        }

        await _context.SaveChangesAsync();
        return entity;
    }

    public async virtual Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entry = _context.Entry(entity);
        if (entry.State == EntityState.Detached)
        {
            Set.Attach(entity);
            entry.State = EntityState.Modified;
        }

        await _context.SaveChangesAsync();
        return entity;
    }

    public async virtual Task<bool> DeleteAsync(Guid id)
    {
        var entity = await Set.FindAsync(id);
        if (entity is null)
        {
            return false;
        }

        Set.Remove(entity);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}