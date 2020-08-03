using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabAssist_V_3._0.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerType = table.Column<string>(nullable: false),
                    CustomerName = table.Column<string>(maxLength: 250, nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    ContactNumber = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DoctorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(maxLength: 250, nullable: false),
                    Address = table.Column<string>(maxLength: 250, nullable: false),
                    ContactNumber = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(maxLength: 100, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 100, nullable: true),
                    DoctorID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_Doctor_Doctor_DoctorID1",
                        column: x => x.DoctorID1,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(maxLength: 250, nullable: true),
                    ItemCatergory = table.Column<int>(nullable: false),
                    UOM = table.Column<int>(nullable: false),
                    ItemPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    UserID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_User_UserID1",
                        column: x => x.UserID1,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    JobID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    DoctorID = table.Column<int>(nullable: false),
                    JobDate = table.Column<DateTime>(nullable: false),
                    Branch = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.JobID);
                    table.ForeignKey(
                        name: "FK_Job_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Job_Doctor_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestComponent",
                columns: table => new
                {
                    TestComponentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(nullable: false),
                    ComponentName = table.Column<string>(nullable: false),
                    UOM = table.Column<int>(nullable: false),
                    RefRange = table.Column<float>(nullable: false),
                    Percentage = table.Column<decimal>(nullable: false),
                    CTM = table.Column<float>(nullable: false),
                    CMax = table.Column<float>(nullable: false),
                    CMin = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestComponent", x => x.TestComponentID);
                    table.ForeignKey(
                        name: "FK_TestComponent_Item_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvocieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    InvoiceData = table.Column<DateTime>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    InvoiceTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvocieID);
                    table.ForeignKey(
                        name: "FK_Invoice_Job_JobID",
                        column: x => x.JobID,
                        principalTable: "Job",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoice_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestResult",
                columns: table => new
                {
                    TestResultID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestComponentID = table.Column<int>(nullable: false),
                    JobID = table.Column<int>(nullable: false),
                    Result = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResult", x => x.TestResultID);
                    table.ForeignKey(
                        name: "FK_TestResult_Job_JobID",
                        column: x => x.JobID,
                        principalTable: "Job",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestResult_TestComponent_TestComponentID",
                        column: x => x.TestComponentID,
                        principalTable: "TestComponent",
                        principalColumn: "TestComponentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItem",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItem", x => new { x.InvoiceID, x.ItemID });
                    table.ForeignKey(
                        name: "FK_InvoiceItem_Invoice_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoice",
                        principalColumn: "InvocieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceItem_Item_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceID = table.Column<int>(nullable: false),
                    PaymentMethod = table.Column<int>(nullable: false),
                    PaymentType = table.Column<int>(nullable: false),
                    PaymentAmount = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payment_Invoice_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoice",
                        principalColumn: "InvocieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CashBook",
                columns: table => new
                {
                    CashTableID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(nullable: false),
                    CashBookType = table.Column<int>(nullable: false),
                    PaymentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashBook", x => x.CashTableID);
                    table.ForeignKey(
                        name: "FK_CashBook_Payment_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payment",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashBook_PaymentID",
                table: "CashBook",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_DoctorID1",
                table: "Doctor",
                column: "DoctorID1");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_JobID",
                table: "Invoice",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_UserID",
                table: "Invoice",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_ItemID",
                table: "InvoiceItem",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CustomerId",
                table: "Job",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_DoctorID",
                table: "Job",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_InvoiceID",
                table: "Payment",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_TestComponent_ItemID",
                table: "TestComponent",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_TestResult_JobID",
                table: "TestResult",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_TestResult_TestComponentID",
                table: "TestResult",
                column: "TestComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserID1",
                table: "User",
                column: "UserID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashBook");

            migrationBuilder.DropTable(
                name: "InvoiceItem");

            migrationBuilder.DropTable(
                name: "TestResult");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "TestComponent");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Doctor");
        }
    }
}
