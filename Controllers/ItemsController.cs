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
    public class ItemsController : Controller
    {
        private readonly LabAssistDbContext _context;

        public ItemsController(LabAssistDbContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }



        // GET: Items/AddOrEdit
        // GET: Items/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEditAsync(int id = 0)
        {
            if (id == 0)
                return View(new Item());
            else
            {
                var item = await _context.Items.FindAsync(id);
                if (item == null)
                {
                    return NotFound();
                }
                return View(item);
            }
        }

        // POST: Items/AddOrEdit
        // POST: Items/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("ItemID,ItemName,ItemCatergory,UOM,ItemPrice")] Item item)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(item);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(item);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ItemExists(item.ItemID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Items.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", item) });
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Items.ToList()) });
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemID == id);
        }
    }
}
