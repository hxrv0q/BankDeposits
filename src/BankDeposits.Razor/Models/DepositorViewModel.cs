namespace BankDeposits.Razor.Models;

public class DepositorViewModel
{
    public Guid Id { get; set; }
    
    public string FullName { get; set; } = string.Empty;

    public string Passport { get; set; } = string.Empty;
    
    public string Address { get; set; } = string.Empty;
}
