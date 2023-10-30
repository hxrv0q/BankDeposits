using System.ComponentModel.DataAnnotations;

namespace BankDeposits.Razor.Models;

public class DepositCreateModel
{
    [Required]
    public Guid AccountId { get; init; }

    [Required, Range(0, 100, ErrorMessage = "The rate must be between 0 and 100")]
    public decimal Rate { get; init; }

    [Required, Range(0, 1_000_000_000, ErrorMessage = "The amount must be between 0 and 1 000 000 000")]
    public decimal Amount { get; init; }

    [Required, Compare(nameof(EndDate), ErrorMessage = "The start date must be less than the end date")]
    public DateTime StartDate { get; init; }

    [Required, Compare(nameof(StartDate), ErrorMessage = "The end date must be greater than the start date")]
    public DateTime EndDate { get; init; }
}