using BankDeposits.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BankDeposits.Domain.Database;

public sealed class AppDbContext : DbContext
{
    public DbSet<Depositor> Depositors { get; set; } = default!;
    public DbSet<Account> Accounts { get; set; } = default!;
    public DbSet<Deposit> Deposits { get; set; } = default!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder builder) => builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly).Seed();
}