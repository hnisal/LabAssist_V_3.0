using Microsoft.EntityFrameworkCore.Migrations;

namespace LabAssist_V_3._0.Migrations
{
    public partial class addedInvoiceState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceState",
                table: "Invoices",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceState",
                table: "Invoices");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
