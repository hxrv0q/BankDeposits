using BankDeposits.Domain.Models;
using System.Collections;

namespace BankDeposits.Domain.Services.Interfaces;

public interface IAccountService : IService<Account>
{
    Task<Account?> GetByNumberAsync(string number);
}