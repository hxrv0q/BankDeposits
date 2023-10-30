using BankDeposits.Domain.Database;
using BankDeposits.Domain.Exceptions;
using BankDeposits.Domain.Models;
using BankDeposits.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BankDeposits.Domain.Services;

public class AccountService : GenericService<Account>, IAccountService
{
    public AccountService(AppDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Account>> GetAllAsync() => await Set.Include(x => x.Deposits).ToListAsync();

    public override async Task<Account?> FindAsync(Expression<Func<Account, bool>> predicate) => await Set.Include(x => x.Deposits).FirstOrDefaultAsync(predicate);

    public override async Task<Account> GetAsync(Guid id) => await Set.Include(x => x.Deposits).FirstOrDefaultAsync(x => x.Id == id) ?? throw new EntityNotFoundException(nameof(Account));

    public Task<Account?> GetByNumberAsync(string number) => FindAsync(x => x.Number == number);
}