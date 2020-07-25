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
    public class TestCompoentsController : Controller
    {
        private readonly LabAssistDbContext _context;

        public TestCompoentsController(LabAssistDbContext context)
        {
            _context = context;
        }

        // GET: TestCompoents
        public async Task<IActionResult> Index()
        {
            var labAssistDbContext = _context.TestCompoents.Include(t => t.Item);
            return View(await labAssistDbContext.ToListAsync());
        }

        // GET: TestCompoents/Create
        public IActionResult Create()
        {
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName");
            return View();
        }

        // POST: TestCompoents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TestComponentID,ComponentName,UOM,RefRange,Percentage,CTM,CMax,CMin,ItemID")] TestCompoent testCompoent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testCompoent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName", testCompoent.ItemID);
            return View(testCompoent);
        }

        // GET: TestCompoents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testCompoent = await _context.TestCompoents.FindAsync(id);
            if (testCompoent == null)
            {
                return NotFound();
            }
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName", testCompoent.ItemID);
            return View(testCompoent);
        }

        // POST: TestCompoents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TestComponentID,ComponentName,UOM,RefRange,Percentage,CTM,CMax,CMin,ItemID")] TestCompoent testCompoent)
        {
            if (id != testCompoent.TestComponentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testCompoent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestCompoentExists(testCompoent.TestComponentID))
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
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName", testCompoent.ItemID);
            return View(testCompoent);
        }

        // GET: TestCompoents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testCompoent = await _context.TestCompoents
                .Include(t => t.Item)
                .FirstOrDefaultAsync(m => m.TestComponentID == id);
            if (testCompoent == null)
            {
                return NotFound();
            }

            return View(testCompoent);
        }

        // POST: TestCompoents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testCompoent = await _context.TestCompoents.FindAsync(id);
            _context.TestCompoents.Remove(testCompoent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestCompoentExists(int id)
        {
            return _context.TestCompoents.Any(e => e.TestComponentID == id);
        }
    }
}
