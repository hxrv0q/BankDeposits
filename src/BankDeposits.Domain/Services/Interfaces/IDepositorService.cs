using BankDeposits.Domain.Models;

namespace BankDeposits.Domain.Services.Interfaces;

public interface IDepositorService : IService<Depositor>
{
    Task<Depositor?> GetByPassportNumberAsync(string passportNumber);
}
