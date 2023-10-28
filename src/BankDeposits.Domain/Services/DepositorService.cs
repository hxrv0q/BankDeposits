using BankDeposits.Domain.Database;
using BankDeposits.Domain.Models;
using BankDeposits.Domain.Services.Interfaces;

namespace BankDeposits.Domain.Services;

public class DepositorService : GenericService<Depositor>, IDepositorService
{
    public DepositorService(AppDbContext context) : base(context)
    {
    }

    public async Task<Depositor?> GetByPassportNumberAsync(string passportNumber) => await FindAsync(x => x.PassportNumber == passportNumber);
}
