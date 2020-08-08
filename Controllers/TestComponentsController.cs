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
    public class TestComponentsController : Controller
    {
        private readonly LabAssistDbContext _context;

        public TestComponentsController(LabAssistDbContext context)
        {
            _context = context;
        }

        // GET: TestComponents
        public async Task<IActionResult> Index()
        {
            var labAssistDbContext = _context.TestComponent.Include(t => t.Item);
            return View(await labAssistDbContext.ToListAsync());
        }

        // GET: TestComponents/AddOrEdit
        // GET: TestComponents/AddOrEdit/5
        [NoDirectAccess]

        public async Task<IActionResult> AddOrEditAsync(int id = 0)
        {
            if (id == 0)
            {
                ViewData["ItemID"] = new SelectList(_context.Item, "ItemID", "ItemName");
                return View(new TestComponent());
            }
            else
            {
                var testComponent = await _context.TestComponent.FindAsync(id);
                if (testComponent == null)
                {
                    return NotFound();
                }
                ViewData["ItemID"] = new SelectList(_context.Item, "ItemID", "ItemName", testComponent.ItemID);
                return View(testComponent);
            }
            
        }

        // POST: TestComponents/AddOrEdit
        // POST: TestComponents/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("TestComponentID,ItemID,ComponentName,UOM,RefRange,Percentage,CTM,CMax,CMin")] TestComponent testComponent)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(testComponent);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(testComponent);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TestComponentExists(testComponent.TestComponentID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.TestComponent.ToList()) });
            }
            ViewData["ItemID"] = new SelectList(_context.Item, "ItemID", "ItemName", testComponent.ItemID);
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", testComponent) });
        }

        // POST: TestComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testComponent = await _context.TestComponent.FindAsync(id);
            _context.TestComponent.Remove(testComponent);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.TestComponent.ToList()) });
        }

        private bool TestComponentExists(int id)
        {
            return _context.TestComponent.Any(e => e.TestComponentID == id);
        }
    }
}
