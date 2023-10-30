using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace BankDeposits.Razor.Models;

public class DepositorCreateModel
{
    [Required, RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "{0} should contain only letters")]
    [StringLength(50, ErrorMessage = "{0} cannot be longer than 50 characters")]
    public string Name { get; init; } = string.Empty;

    [Required, RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "{0} should contain only letters")]
    [StringLength(50, ErrorMessage = "{0} cannot be longer than 50 characters")]
    public string Surname { get; init; } = string.Empty;

    [Required, RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "{0} should contain only letters")]
    [StringLength(50, ErrorMessage = "{0} cannot be longer than 50 characters")]
    public string Patronymic { get; init; } = string.Empty;

    [Required, RegularExpression(@"^[A-Z]{2}$", ErrorMessage = "{0} should contain only one capital letter")]
    public string PassportSeries { get; init; } = string.Empty;

    [Required, RegularExpression(@"^[0-9]{6}$", ErrorMessage = "{0} should contain only 6 digits")]
    public string PassportNumber { get; init; } = string.Empty;

    [Required, RegularExpression(@"^[a-zA-Zа-яА-Я0-9\s]+$", ErrorMessage = "{0} should contain only letters and digits")]
    [StringLength(100, ErrorMessage = "{0} cannot be longer than 100 characters")]
    public string Address { get; init; } = string.Empty;
}