namespace BankDeposits.Razor.Models;

public class DepositViewModel
{
    public Guid Id { get; init; }
    public Guid AccountId { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public decimal Rate { get; init; }
    public decimal Amount { get; init; }
    public decimal Profit { get; init; }
}