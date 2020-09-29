using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaBancario.Domain.Models;

namespace SistemaBancario.Infra.Data.Mappings
{
    public class BankAccountDailyInfoMap : IEntityTypeConfiguration<BankAccountDailyInfoModel>
    {
        public void Configure(EntityTypeBuilder<BankAccountDailyInfoModel> builder)
        {
            builder.ToTable("bank_account_daily_info");

            builder.Property(p => p.BalanceAtDate)
                .HasColumnName("balance_at_date")
                .HasColumnType("decimal(13, 2)")
                .IsRequired();

            builder.Property(p => p.IncomeBalance)
                .HasColumnName("income_balance")
                .HasColumnType("decimal(13, 2)")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(p => p.ReferenceDate)
                .HasColumnName("reference_date")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.BankAccountId)
               .HasColumnName("bank_account_id")
               .IsRequired();

            builder.HasIndex(p => new { p.BankAccountId, p.ReferenceDate })
                .IsUnique();

            builder.HasOne<BankAccountModel>(p => p.BankAccount)
                .WithMany(p => p.DailyInfos)
                .HasForeignKey(p => p.BankAccountId);
        }
    }
}
