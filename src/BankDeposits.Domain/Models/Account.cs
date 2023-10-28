using System.ComponentModel.DataAnnotations.Schema;

namespace BankDeposits.Domain.Models;

public class Account
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public decimal Balance { get; set; }
    public required string Number { get; set; }
    public Depositor Owner { get; set; } = null!;
    public ICollection<Deposit>? Deposits { get; set; }
    [NotMapped]
    public decimal TotalProfit => Deposits?.Sum(x => x.Profit) ?? 0;
}