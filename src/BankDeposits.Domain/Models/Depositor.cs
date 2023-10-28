using System.ComponentModel.DataAnnotations.Schema;

namespace BankDeposits.Domain.Models;

public class Depositor
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Patronymic { get; set; }
    public required string PassportSeries { get; set; }
    public required string PassportNumber { get; set; }
    public required string Address { get; set; }
    public ICollection<Account>? Accounts { get; set; }
    [NotMapped]
    public string FullName => $"{Surname} {Name} {Patronymic}";
    [NotMapped] 
    public string Passport => $"{PassportSeries} {PassportNumber}";
}