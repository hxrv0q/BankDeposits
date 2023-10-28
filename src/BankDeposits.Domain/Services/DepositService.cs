using BankDeposits.Domain.Database;
using BankDeposits.Domain.Models;
using BankDeposits.Domain.Services.Interfaces;

namespace BankDeposits.Domain.Services;

public class DepositService : GenericService<Deposit>, IDepositService
{
    public DepositService(AppDbContext context) : base(context)
    {
    }
}