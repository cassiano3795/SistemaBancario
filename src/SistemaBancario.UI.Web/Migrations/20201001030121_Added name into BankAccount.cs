using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaBancario.UI.Web.Migrations
{
    public partial class AddednameintoBankAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "bank_account",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "bank_account");
        }
    }
}
