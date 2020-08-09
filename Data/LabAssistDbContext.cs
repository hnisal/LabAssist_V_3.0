using LabAssist_V_3._0.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceItem>()
                .HasKey(c => new { c.InvoiceID, c.ItemID });
        }

        public DbSet<CashBook> CashBook { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<TestResult> TestResult { get; set; }
        public DbSet<TestComponent> TestComponent { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<InvoiceItem> InvoiceItem { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<JobCommision> JobCommision { get; set; }

        


    }
}
