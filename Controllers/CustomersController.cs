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
    public class CustomersController : Controller
    {
        private readonly LabAssistDbContext _context;

        public CustomersController(LabAssistDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync());
        }

        // GET: Customers/AddOrEdit
        // GET: Customers/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEditAsync(int id = 0)
        {
            if (id == 0)
                return View(new Customer());
            else
            {
                var customer = await _context.Customer.FindAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return View(customer);
            }

        }

        // POST: Customers/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("CustomerID,CustomerType,CustomerName,Gender,BirthDate,Address,ContactNumber,EmailAddress")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(customer);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(customer);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CustomerExists(customer.CustomerID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Customer.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", customer) });
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Customer.ToList()) });
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.CustomerID == id);
        }

        public ActionResult JobCreate()
        {
            return View("../Jobs/create");
        }
    }
}
