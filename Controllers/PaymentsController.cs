using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabAssist_V_3._0.Data;
using LabAssist_V_3._0.Models;
using System.Runtime.CompilerServices;
using System.Collections;

namespace LabAssist_V_3._0.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly LabAssistDbContext _context;

        public PaymentsController(LabAssistDbContext context)
        {
            _context = context;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            var labAssistDbContext = _context.Payment.Include(p => p.Invoice);
            return View(await labAssistDbContext.ToListAsync());
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment
                .Include(p => p.Invoice)
                .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public async Task<IActionResult> CreateAsync(int? id)
        {
            var payments = from p in _context.Payment
                           select p;
            var invoice = await _context.Invoice.FindAsync(id);
            if (id != invoice.InvocieID)
            {
                return NotFound();
            }

            double paidTotal = 0;
            
            payments = payments.Where(p => p.InvoiceID == id);
            foreach (var single in payments)
            {
                paidTotal += single.PaymentAmount;
            }
            double dueAmount = invoice.InvoiceTotal - paidTotal;

            ViewBag.PaidTotal = paidTotal;
            ViewBag.DueAmount = dueAmount;
            ViewData["InvoiceID"] = new SelectList(_context.Invoice, "InvocieID", "InvocieID", invoice.InvocieID);
            return View();
        }

        // POST: Payments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentID,InvoiceID,PaymentMethod,PaymentType,PaymentAmount")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Invoices");
            }
            ViewData["InvoiceID"] = new SelectList(_context.Invoice, "InvocieID", "InvocieID", payment.InvoiceID);
            return View(payment);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            ViewData["InvoiceID"] = new SelectList(_context.Invoice, "InvocieID", "InvocieID", payment.InvoiceID);
            return View(payment);
        }

        // POST: Payments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentID,InvoiceID,PaymentMethod,PaymentType,PaymentAmount")] Payment payment)
        {
            if (id != payment.PaymentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.PaymentID))
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
            ViewData["InvoiceID"] = new SelectList(_context.Invoice, "InvocieID", "InvocieID", payment.InvoiceID);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment
                .Include(p => p.Invoice)
                .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payment = await _context.Payment.FindAsync(id);
            _context.Payment.Remove(payment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
            return _context.Payment.Any(e => e.PaymentID == id);
        }

        private void GetInvoiceDetails(Payment payment)
        {
            int id = payment.PaymentID;
            ArrayList invoiceDetailList = new ArrayList();

        }
    }
}
