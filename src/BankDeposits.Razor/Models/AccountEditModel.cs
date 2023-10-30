using System.ComponentModel.DataAnnotations;

namespace BankDeposits.Razor.Models;

public class AccountEditModel
{
    [Required]
    public Guid Id { get; init; }

    [Required, Range(0, 1_000_000_000, ErrorMessage = "The balance must be between 0 and 1 000 000 000")]
    public decimal Balance { get; init; }
}