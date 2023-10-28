using BankDeposits.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankDeposits.Domain.Database.Config;

public class DepositorConfiguration : IEntityTypeConfiguration<Depositor>
{

    public void Configure(EntityTypeBuilder<Depositor> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Surname).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Patronymic).HasMaxLength(50).IsRequired();
        builder.Property(x => x.PassportNumber).HasMaxLength(6).IsRequired();
        builder.Property(x => x.PassportSeries).HasMaxLength(2).IsRequired();
        builder.Property(x => x.Address).HasMaxLength(100).IsRequired();

        builder.HasIndex(x => x.PassportNumber).IsUnique();

        builder.HasMany(x => x.Accounts).WithOne(x => x.Owner).HasForeignKey(x => x.OwnerId).OnDelete(DeleteBehavior.Cascade);
    }
}