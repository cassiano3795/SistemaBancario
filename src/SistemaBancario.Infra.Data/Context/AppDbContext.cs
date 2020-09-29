using Microsoft.EntityFrameworkCore;
using SistemaBancario.Domain.Models;
using SistemaBancario.Infra.Data.Mappings;

namespace SistemaBancario.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<BankAccountModel> BankAccounts { get; set; }
        public DbSet<TransactionModel> Transactions { get; set; }
        public DbSet<BankAccountDailyInfoModel> BankAccountDailyInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BankAccountMap());
            modelBuilder.ApplyConfiguration(new TransactionMap());
            modelBuilder.ApplyConfiguration(new BankAccountDailyInfoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
