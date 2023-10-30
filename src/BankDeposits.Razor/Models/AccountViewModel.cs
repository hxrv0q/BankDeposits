namespace BankDeposits.Razor.Models;

public class AccountViewModel
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public decimal Balance { get; set; }
    public string Number { get; set; } = string.Empty;
    public decimal TotalProfit { get; set; }
}