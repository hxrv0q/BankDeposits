using System.ComponentModel.DataAnnotations;

namespace BankDeposits.Razor.Models;

public class DepositorEditModel
{
    [Required]
    public Guid Id { get; init; }
    
    [Required, RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "{0} should contain only letters")]
    [StringLength(50, ErrorMessage = "{0} cannot be longer than 50 characters")]
    public string Name { get; init; } = string.Empty;

    [Required, RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "{0} should contain only letters")]
    [StringLength(50, ErrorMessage = "{0} cannot be longer than 50 characters")]
    public string Surname { get; init; } = string.Empty;

    [Required, RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "{0} should contain only letters")]
    [StringLength(50, ErrorMessage = "{0} cannot be longer than 50 characters")]
    public string Patronymic { get; init; } = string.Empty;

    [Required, RegularExpression(@"^[a-zA-Zа-яА-Я0-9\s]+$", ErrorMessage = "{0} should contain only letters and digits")]
    [StringLength(100, ErrorMessage = "{0} cannot be longer than 100 characters")]
    public string Address { get; init; } = string.Empty;
}