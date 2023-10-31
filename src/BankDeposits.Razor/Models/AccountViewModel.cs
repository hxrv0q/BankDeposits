namespace BankDeposits.Razor.Models;

public class AccountViewModel
{
    public Guid Id { get; init; }
    public Guid OwnerId { get; init; }
    public decimal Balance { get; init; }
    public string Number { get; init; } = string.Empty;
    public decimal TotalProfit { get; init; }
}