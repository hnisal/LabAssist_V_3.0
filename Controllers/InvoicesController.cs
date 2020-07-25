using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabAssist_V_3._0.Data;

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
            return View(await _context.Invoices.ToListAsync());
        }

        // GET: Invoices/AddOrEdit
        // GET: Invoices/AddOrEdit/5
        [NoDirectAccess]

        public async Task<IActionResult> AddOrEditAsync(int id = 0)
        {
            if (id == 0)
                return View(new Invoice());
            else
            {
                var invoice = await _context.Invoices.FindAsync(id);
                if (invoice == null)
                {
                    return NotFound();
                }
                return View(invoice);
            }
        }

        // POST: Invoices/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("InvocieID,PreparedBy,InvoiceData,InvoiceState")] Invoice invoice)
        {

            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(invoice);
                    await _context.SaveChangesAsync();
                }
                else
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
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Invoices.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", invoice) });
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Invoices.ToList()) });
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.InvocieID == id);
        }
    }
}
