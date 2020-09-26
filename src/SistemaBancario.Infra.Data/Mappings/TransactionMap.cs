using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaBancario.Domain.Models;

namespace SistemaBancario.Infra.Data.Mappings
{
    public class TransactionMap : IEntityTypeConfiguration<TransactionModel>
    {
        public void Configure(EntityTypeBuilder<TransactionModel> builder)
        {
            builder.ToTable("transaction");

            builder.Property(p => p.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.TransactionType)
                .HasColumnName("transation_type")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne<BankAccountModel>(p => p.BankAccount)
                .WithMany(p => p.Transactions)
                .HasForeignKey(p => p.BankAccountId);
        }
    }
}
