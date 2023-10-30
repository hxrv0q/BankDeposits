using System.ComponentModel.DataAnnotations;

namespace BankDeposits.Razor.Models;

public class DepositEditModel
{
    [Required]
    public Guid Id { get; init; }

    [Required, Range(0, 100, ErrorMessage = "The rate must be between 0 and 100")]
    public decimal Rate { get; init; }
}