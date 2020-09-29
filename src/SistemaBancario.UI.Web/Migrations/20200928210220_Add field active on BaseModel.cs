using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaBancario.UI.Web.Migrations
{
    public partial class AddfieldactiveonBaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "transaction",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "bank_account",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "active",
                table: "transaction");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "bank_account");
        }
    }
}
