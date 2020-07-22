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
    public class DoctorsController : Controller
    {
        private readonly LabAssistDbContext _context;

        public DoctorsController(LabAssistDbContext context)
        {
            _context = context;
        }

        // GET: Doctors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doctors.ToListAsync());
        }


        // GET: Doctors/AddOrEdit
        // GET: Doctors/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEditAsync(int id= 0)
        {
            if (id == 0)
                return View(new Doctor());
            else
            {
                var doctor = await _context.Doctors.FindAsync(id);
                if (doctor == null)
                {
                    return NotFound();
                }
                return View(doctor);
            }
                
        }

        // POST: Doctors/AddOrEdit
        // POST: Doctors/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("DoctorID,DoctorName,Address,ContactNumber,Designation,EmailAddress")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(doctor);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(doctor);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DoctorExists(doctor.DoctorID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Doctors.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", doctor) });
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Doctors.ToList()) });
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.DoctorID == id);
        }
    }
}
