namespace BankDeposits.Razor.Models;

public class DepositorViewModel
{
    public Guid Id { get; init; }
    public string FullName { get; init; } = string.Empty;
    public string Passport { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
}
