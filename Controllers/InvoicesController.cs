using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabAssist_V_3._0.Data;
using LabAssist_V_3._0.Models;
using LabAssist_V_3._0.Models.ViewModels;

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
        public async Task<IActionResult> Index(int? id)
        {
            var viewModel = new InvoiceIndexData();
            viewModel.Invoice = await _context.Invoice
                  .Include(i => i.Job)
                  .Include(i => i.InvoiceItem)
                    .ThenInclude(i => i.Item)
                     .ThenInclude(i => i.TestCompoent)
                  .ToListAsync();

            if (id != null)
            {
                ViewData["InvoiceID"] = id.Value;
                Invoice invoice = viewModel.Invoice.Where(
                    i => i.InvocieID == id.Value).Single();
                viewModel.Item = invoice.InvoiceItem.Select(s => s.Item);
            }


            //if (itemID != null)
            //{
            //    ViewData["ItemID"] = itemID.Value;
            //    var selectedItem = viewModel.Item.Where(x => x.ItemID == itemID).Single();
            //    await _context.Entry(selectedItem).Collection(x => x.Enrollments).LoadAsync();
            //    foreach (Enrollment enrollment in selectedCourse.Enrollments)
            //    {
            //        await _context.Entry(enrollment).Reference(x => x.Student).LoadAsync();
            //    }
            //    viewModel.Enrollments = selectedCourse.Enrollments;
            //}


            //var labAssistDbContext = _context.Invoice.Include(i => i.Job).Include(i => i.User);
            //return View(await labAssistDbContext.ToListAsync());

            return View(viewModel);
        }

        // GET: Invoices/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var invoice = await _context.Invoice
        //        .Include(i => i.Job)
        //        .Include(i => i.User)
        //        .FirstOrDefaultAsync(m => m.InvocieID == id);
        //    if (invoice == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(invoice);
        //}

        // GET: Invoices/Create
        public async Task<IActionResult> CreateAsync(int id)
        {
            var job = await _context.Job.FindAsync(id);

            var invoice = new Invoice();
            invoice.InvoiceItem = new List<InvoiceItem>();
            PopulateInvoiceItems(invoice);


            if (id != job.JobID)
            {
                return NotFound();
            }

            ViewData["JobID"] = new SelectList(_context.Job, "JobID", "JobID", job.JobID);
            return View();


            
        }

       
        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvocieID,JobID,InvoiceData,InvoiceState,InvoiceTotal")] Invoice invoice , string[] selectedItems)
        {
            ViewBag.invoiceTotal = null;

            if (selectedItems != null)
            {

                invoice.InvoiceItem = new List<InvoiceItem>();
                foreach (var item in selectedItems)
                {
                    var itemToAdd = new InvoiceItem { InvoiceID = invoice.InvocieID, ItemID = int.Parse(item) };
                    invoice.InvoiceItem.Add(itemToAdd);
                }
            }


            var jobCommision = new JobCommision
            {
                JobID = invoice.JobID,
                CreatedDate = invoice.InvoiceData,
                Earning = invoice.InvoiceTotal * 3/100
            };

            if (ModelState.IsValid)
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                _context.Add(jobCommision);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobID"] = new SelectList(_context.Job, "JobID", "JobID", invoice.JobID);
            PopulateInvoiceItems(invoice);



            




            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                  .Include(i => i.Job)
                  .Include(i => i.InvoiceItem).ThenInclude(i => i.Item)
                  .AsNoTracking()
                  .FirstOrDefaultAsync(m => m.InvocieID == id);

            if (invoice == null)
            {
                return NotFound();
            }
            PopulateInvoiceItems(invoice);

            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedItems)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceToUpdate = await _context.Invoice
                  .Include(i => i.Job)
                  .Include(i => i.InvoiceItem)
                    .ThenInclude(i => i.Item)
                .FirstOrDefaultAsync(m => m.InvocieID == id);

            if (await TryUpdateModelAsync<Invoice>(
               invoiceToUpdate,
               "",
                 i => i.JobID, i => i.InvoiceData, i => i.InvoiceState, i => i.InvoiceTotal))
            {
                UpdateInvoiceItems(selectedItems, invoiceToUpdate);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            UpdateInvoiceItems(selectedItems, invoiceToUpdate);
            PopulateInvoiceItems(invoiceToUpdate);
            return View(invoiceToUpdate);
        }
        


        private void UpdateInvoiceItems(string[] selectedItems, Invoice invoiceToUpdate)
        {
            if (selectedItems == null)
            {
                invoiceToUpdate.InvoiceItem = new List<InvoiceItem>();
                return;
            }

            var selectedItemsHS = new HashSet<string>(selectedItems);
            var inviceItems = new HashSet<int>
                (invoiceToUpdate.InvoiceItem.Select(c => c.Item.ItemID));
            foreach (var item in _context.Item)
            {
                if (selectedItemsHS.Contains(item.ItemID.ToString()))
                {
                    if (!inviceItems.Contains(item.ItemID))
                    {
                        invoiceToUpdate.InvoiceItem.Add(new InvoiceItem { InvoiceID = invoiceToUpdate.InvocieID, ItemID = item.ItemID });
                    }
                }
                else
                {

                    if (inviceItems.Contains(item.ItemID))
                    {
                        InvoiceItem itemToRemove = invoiceToUpdate.InvoiceItem.FirstOrDefault(i => i.ItemID == item.ItemID);
                        _context.Remove(itemToRemove);
                    }
                }
            }
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
                .FirstOrDefaultAsync(m => m.InvocieID == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        private void PopulateInvoiceItems(Invoice invoice)
        {

            var allItems = _context.Item;
            var invoiceItems = new HashSet<int>(invoice.InvoiceItem.Select(c => c.ItemID));
            var viewModel = new List<SelectedItemData>();
            foreach (var item in allItems)
            {
                viewModel.Add(new SelectedItemData
                {
                    ItemID = item.ItemID,
                    ItemName = item.ItemName,
                    ItemPrice = item.ItemPrice,
                    Assigned = invoiceItems.Contains(item.ItemID)
                });
            }
            ViewData["Items"] = viewModel;
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Invoice invoices = await _context.Invoice
                .Include(i => i.InvoiceItem)
                .SingleAsync(i => i.InvocieID == id);

            var invoice = await _context.Invoice.FindAsync(id);
            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoice.Any(e => e.InvocieID == id);
        }

        // GET: Invoices
        public async Task<IActionResult> Print(int? id)
        {
            var viewModel = new InvoiceFinal();
            viewModel.Invoice = await _context.Invoice
                  .Include(i => i.Job)
                     .ThenInclude(i => i.Doctor)
                     
                  .Include(i => i.Payment)
                  .Include(i => i.InvoiceItem)
                      .ThenInclude(i => i.Item)
                  .ToListAsync();

            if (id != null)
            {
                ViewData["InvoiceID"] = id.Value;
                Invoice invoice = viewModel.Invoice.Where(
                    i => i.InvocieID == id.Value).Single();
                viewModel.Item = invoice.InvoiceItem.Select(s => s.Item);
            }

            return View(viewModel);
        }

    }
}



