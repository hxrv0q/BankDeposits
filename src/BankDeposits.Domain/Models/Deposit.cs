using System.ComponentModel.DataAnnotations.Schema;

namespace BankDeposits.Domain.Models;

public class Deposit
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Rate { get; set; }
    public decimal Amount { get; set; }
    public Account Account { get; set; } = null!;

    [NotMapped]
    public decimal Profit => Amount * Rate / 100;
}