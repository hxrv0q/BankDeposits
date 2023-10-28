using BankDeposits.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankDeposits.Domain.Database.Config;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{

    public void Configure(EntityTypeBuilder<Account> builder)
    {

        builder.ToTable(nameof(Account));
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.OwnerId).IsRequired();
        builder.Property(x => x.Balance).HasPrecision(18 ,2).IsRequired();
        builder.Property(x => x.Number).HasMaxLength(16).IsFixedLength().IsRequired();
        
        builder.HasIndex(x => x.Number).IsUnique();
        
        builder.HasOne(x => x.Owner).WithMany(x => x.Accounts).HasForeignKey(x => x.OwnerId).OnDelete(DeleteBehavior.Cascade);
    }
}