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
    private readonly DbSet<TEntity> _set;

    protected GenericService(AppDbContext context)
    {
        _context = context;
        _set = _context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() => await _set.ToListAsync();


    public async Task<TEntity> GetAsync(Guid id) => await _set.FindAsync(id) ?? throw new EntityNotFoundException(typeof(TEntity).Name);

    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate) => await _set.Where(predicate).FirstOrDefaultAsync();

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var entry = _context.Entry(entity);
        if (entry.State == EntityState.Detached)
        {
            _set.Add(entity);
        }

        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entry = _context.Entry(entity);
        if (entry.State == EntityState.Detached)
        {
            _set.Attach(entity);
            entry.State = EntityState.Modified;
        }

        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _set.FindAsync(id);
        if (entity is null)
        {
            return false;
        }

        _set.Remove(entity);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}