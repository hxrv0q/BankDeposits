using System.Data;
using BankDeposits.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BankDeposits.Domain.Database;

public static class AppDbContextSeed
{
    public static void Seed(this ModelBuilder builder) => builder.GenerateData();

    private static void GenerateData(this ModelBuilder builder)
    {
        const string depositorGuid = "d0b9c9a0-1b1a-4b1a-9f0a-0b0a0b0a0b0a";
        const string accountGuid = "a0b9c9a0-1b1a-4b1a-9f0a-0b0a0b0a0b0a";

        builder.Entity<Depositor>().HasData(new Depositor
        {
            Id = Guid.Parse(depositorGuid),
            Name = "Іван",
            Surname = "Ткачук",
            Patronymic = "Васильович",
            PassportSeries = "АА",
            PassportNumber = "123456",
            Address = "м. Львів, вул. Шевченка, 1",
        });

        builder.Entity<Account>().HasData(new Account
        {
            Id = Guid.Parse(accountGuid),
            OwnerId = Guid.Parse(depositorGuid),
            Balance = 1000,
            Number = "1234567890123456",
        });

        builder.Entity<Deposit>().HasData(new Deposit
        {
            Id = Guid.NewGuid(),
            AccountId = Guid.Parse(accountGuid),
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.Now.AddYears(1),
            Rate = 10,
            Amount = 1000,
        });

        builder.Entity<Deposit>().HasData(new Deposit
        {
            Id = Guid.NewGuid(),
            AccountId = Guid.Parse(accountGuid),
            StartDate = DateTime.UtcNow.AddDays(-3),
            EndDate = DateTime.Now.AddYears(1),
            Rate = 10,
            Amount = 1000,
        });
    }
}