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
    public class InvoiceItemsController : Controller
    {
        private readonly LabAssistDbContext _context;

        public InvoiceItemsController(LabAssistDbContext context)
        {
            _context = context;
        }

        // GET: InvoiceItems
        public async Task<IActionResult> Index()
        {
            var labAssistDbContext = _context.InvoiceItems.Include(i => i.Item).Include(i => i.Laboratory);
            return View(await labAssistDbContext.ToListAsync());
        }

        // GET: InvoiceItems/AddOrEdit
        // GET: InvoiceItems/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEditAsync(int id = 0)
        {
            if (id == 0)
            {
                ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName");
                ViewData["LaboratoryID"] = new SelectList(_context.Laboratories, "LaboratoryID", "LaboratoryName");
                return View(new InvoiceItem());
            }
            else
            {
                var invoiceItem = await _context.InvoiceItems.FindAsync(id);
                if (invoiceItem == null)
                {
                    return NotFound();
                }
                ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName", invoiceItem.ItemID);
                ViewData["LaboratoryID"] = new SelectList(_context.Laboratories, "LaboratoryID", "LaboratoryName", invoiceItem.LaboratoryID);
                return View(invoiceItem);
            }
        }

        // POST: InvoiceItems/AddOrEdit
        // POST: InvoiceItems/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("InvoiceItemID,ItemID,LaboratoryID,UOM,Quantity,Price")] InvoiceItem invoiceItem)
        {
            if (ModelState.IsValid)
            {

                if (id == 0)
                {
                    _context.Add(invoiceItem);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(invoiceItem);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!InvoiceItemExists(invoiceItem.InvoiceItemID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.InvoiceItems.ToList()) });
                }
            }

            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName", invoiceItem.ItemID);
            ViewData["LaboratoryID"] = new SelectList(_context.Laboratories, "LaboratoryID", "LaboratoryName", invoiceItem.LaboratoryID);
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", invoiceItem) });
        }

        // POST: InvoiceItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceItem = await _context.InvoiceItems.FindAsync(id);
            _context.InvoiceItems.Remove(invoiceItem);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.InvoiceItems.ToList()) });
        }

        private bool InvoiceItemExists(int id)
        {
            return _context.InvoiceItems.Any(e => e.InvoiceItemID == id);
        }
    }
}
