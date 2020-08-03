using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabAssist_V_3._0.Data;
using LabAssist_V_3._0.Models;

namespace LabAssist_V_3._0.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly LabAssistDbContext _context;

        public InvoicesController(LabAssistDbContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            var labAssistDbContext = _context.Invoice.Include(i => i.Job).Include(i => i.User);
            return View(await labAssistDbContext.ToListAsync());
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.Job)
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.InvocieID == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        public async Task<IActionResult> CreateAsync(int? id)
        {
            var job = await _context.Job.FindAsync(id);
            if (id != job.JobID)
            {
                return NotFound();
            }

            ViewData["JobID"] = new SelectList(_context.Job, "JobID", "JobID", job.JobID);
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserName");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvocieID,JobID,UserID,InvoiceData,InvoiceState,InvoiceTotal")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobID"] = new SelectList(_context.Job, "JobID", "JobID", invoice.JobID);
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserName", invoice.UserID);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["JobID"] = new SelectList(_context.Job, "JobID", "JobID", invoice.JobID);
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserName", invoice.UserID);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvocieID,JobID,UserID,InvoiceData,InvoiceState,InvoiceTotal")] Invoice invoice)
        {
            if (id != invoice.InvocieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.InvocieID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobID"] = new SelectList(_context.Job, "JobID", "JobID", invoice.JobID);
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserName", invoice.UserID);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.Job)
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.InvocieID == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoice.FindAsync(id);
            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoice.Any(e => e.InvocieID == id);
        }
    }
}
