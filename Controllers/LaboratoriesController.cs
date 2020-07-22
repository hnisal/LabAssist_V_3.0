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
    public class LaboratoriesController : Controller
    {
        private readonly LabAssistDbContext _context;

        public LaboratoriesController(LabAssistDbContext context)
        {
            _context = context;
        }

        // GET: Laboratories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Laboratories.ToListAsync());
        }

        // GET: Laboratories/AddOrEdit
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEditAsync(int id = 0)
        {
            if (id == 0)
                return View(new Laboratory());
            else
            {
                var laboratory = await _context.Laboratories.FindAsync(id);
                if (laboratory == null)
                {
                    return NotFound();
                }
                return View(laboratory);
            }
        }

        // POST: Laboratories/AddOrEdit
        // POST: Laboratories/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("LaboratoryID,LaboratoryName,Address,ContactNumber,EmailAddress")] Laboratory laboratory)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(laboratory);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(laboratory);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!LaboratoryExists(laboratory.LaboratoryID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Laboratories.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", laboratory) });
        }

       
        
        // POST: Laboratories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laboratory = await _context.Laboratories.FindAsync(id);
            _context.Laboratories.Remove(laboratory);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Laboratories.ToList()) });
        }

        private bool LaboratoryExists(int id)
        {
            return _context.Laboratories.Any(e => e.LaboratoryID == id);
        }
    }
}
