using BankDeposits.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankDeposits.Domain.Database.Config;

public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
{

    public void Configure(EntityTypeBuilder<Deposit> builder)
    {
        builder.ToTable(nameof(Deposit));

        builder.ToTable(t => t.HasCheckConstraint("CK_Deposit_StartDate", "StartDate <= GETUTCDATE()"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Deposit_EndDate", "EndDate > GETUTCDATE()"));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Amount).HasPrecision(18, 2).IsRequired();
        builder.Property(x => x.Rate).HasPrecision(18, 2).IsRequired();

        builder.Property(x => x.StartDate).IsRequired().HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        builder.Property(x => x.EndDate).IsRequired().HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        builder.HasOne(x => x.Account).WithMany(x => x.Deposits).HasForeignKey(x => x.AccountId).OnDelete(DeleteBehavior.Cascade);
    }
}