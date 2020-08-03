using Microsoft.EntityFrameworkCore.Migrations;

namespace LabAssist_V_3._0.Migrations
{
    public partial class invoiceStateChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Invoice");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceState",
                table: "Invoice",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceState",
                table: "Invoice");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
