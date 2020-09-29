using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaBancario.UI.Web.Migrations
{
    public partial class Addtablebank_account_daily_info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transaction_bank_account_BankAccountId",
                table: "transaction");

            migrationBuilder.RenameColumn(
                name: "BankAccountId",
                table: "transaction",
                newName: "bank_account_id");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_BankAccountId",
                table: "transaction",
                newName: "IX_transaction_bank_account_id");

            migrationBuilder.CreateTable(
                name: "bank_account_daily_info",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: true),
                    balance_at_date = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    income_balance = table.Column<decimal>(type: "decimal(13, 2)", nullable: false, defaultValue: 0m),
                    reference_date = table.Column<DateTime>(type: "date", nullable: false),
                    bank_account_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bank_account_daily_info", x => x.id);
                    table.ForeignKey(
                        name: "FK_bank_account_daily_info_bank_account_bank_account_id",
                        column: x => x.bank_account_id,
                        principalTable: "bank_account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bank_account_daily_info_bank_account_id_reference_date",
                table: "bank_account_daily_info",
                columns: new[] { "bank_account_id", "reference_date" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_bank_account_bank_account_id",
                table: "transaction",
                column: "bank_account_id",
                principalTable: "bank_account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transaction_bank_account_bank_account_id",
                table: "transaction");

            migrationBuilder.DropTable(
                name: "bank_account_daily_info");

            migrationBuilder.RenameColumn(
                name: "bank_account_id",
                table: "transaction",
                newName: "BankAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_bank_account_id",
                table: "transaction",
                newName: "IX_transaction_BankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_bank_account_BankAccountId",
                table: "transaction",
                column: "BankAccountId",
                principalTable: "bank_account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
