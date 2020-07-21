using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Data
{
    public class LabAssistDbContext: DbContext
    {
        public LabAssistDbContext(DbContextOptions<LabAssistDbContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<TestCompoent> TestCompoents { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Laboratory> Laboratories { get; set; }
    }
}
