using Microsoft.EntityFrameworkCore.Migrations;

namespace LabAssist_V_3._0.Migrations
{
    public partial class CommisionTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "InvoiceTotal",
                table: "Invoice",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "InvoiceTotal",
                table: "Invoice",
                type: "float",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
