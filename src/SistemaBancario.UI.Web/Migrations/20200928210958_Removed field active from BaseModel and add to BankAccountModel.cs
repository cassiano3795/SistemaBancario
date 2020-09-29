using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaBancario.UI.Web.Migrations
{
    public partial class RemovedfieldactivefromBaseModelandaddtoBankAccountModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "active",
                table: "transaction");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "bank_account",
                newName: "active");

            migrationBuilder.AlterColumn<ulong>(
                name: "active",
                table: "bank_account",
                type: "bit",
                nullable: false,
                defaultValue: 1ul,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "active",
                table: "bank_account",
                newName: "Active");

            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "transaction",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "bank_account",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldDefaultValue: 1ul);
        }
    }
}
