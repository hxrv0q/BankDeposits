using BankDeposits.Domain.Models;

namespace BankDeposits.Domain.Services.Interfaces;

public interface IAccountService : IService<Account>
{
    public Task<Account?> GetByNumberAsync(string number);
}