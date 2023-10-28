using BankDeposits.Domain.Database;
using BankDeposits.Domain.Models;
using BankDeposits.Domain.Services.Interfaces;

namespace BankDeposits.Domain.Services;

public class AccountService : GenericService<Account>, IAccountService
{
    public AccountService(AppDbContext context) : base(context)
    {
    }

    public Task<Account?> GetByNumberAsync(string number) => FindAsync(x => x.Number == number);
}