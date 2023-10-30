using System.ComponentModel.DataAnnotations;

namespace BankDeposits.Razor.Models;

public class AccountCreateModel
{
    [Required]
    public Guid OwnerId { get; init; }

    [Required, RegularExpression(@"^\d{16}$", ErrorMessage = "The account number must be in the format 0000000000000000")]
    public string Number { get; set; } = string.Empty;

    [Required, Range(0, 1_000_000_000, ErrorMessage = "The balance must be between 0 and 1 000 000 000")]
    public decimal Balance { get; set; }
}