using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaBancario.UI.Web.Migrations
{
    public partial class ChangedthevaluefieldstoDecimal137 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "income_balance",
                table: "bank_account_daily_info",
                type: "decimal(13, 7)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(13, 2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "balance_at_date",
                table: "bank_account_daily_info",
                type: "decimal(13, 7)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(13, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "balance",
                table: "bank_account",
                type: "decimal(13, 7)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(13, 2)",
                oldDefaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "income_balance",
                table: "bank_account_daily_info",
                type: "decimal(13, 2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(13, 7)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "balance_at_date",
                table: "bank_account_daily_info",
                type: "decimal(13, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(13, 7)");

            migrationBuilder.AlterColumn<decimal>(
                name: "balance",
                table: "bank_account",
                type: "decimal(13, 2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(13, 7)",
                oldDefaultValue: 0m);
        }
    }
}
