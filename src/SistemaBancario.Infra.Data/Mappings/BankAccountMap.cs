using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaBancario.Domain.Models;

namespace SistemaBancario.Infra.Data.Mappings
{
    public class BankAccountMap : IEntityTypeConfiguration<BankAccountModel>
    {
        public void Configure(EntityTypeBuilder<BankAccountModel> builder)
        {
            builder.ToTable("bank_account");

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Agency)
                .HasColumnName("agency")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.AccountNumber)
                .HasColumnName("account_number")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Balance)
                .HasColumnName("balance")
                .HasColumnType("decimal(13, 7)")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(p => p.Active)
                .HasColumnName("active")
                .HasColumnType("bit")
                .HasDefaultValue(true)
                .IsRequired();
        }
    }
}
