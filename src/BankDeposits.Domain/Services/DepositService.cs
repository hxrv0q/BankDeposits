using BankDeposits.Domain.Database;
using BankDeposits.Domain.Models;
using BankDeposits.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankDeposits.Domain.Services;

public class DepositService : GenericService<Deposit>, IDepositService
{
    public DepositService(AppDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Deposit>> GetAllAsync() => await Set.Include(x => x.Account).ToListAsync();
}