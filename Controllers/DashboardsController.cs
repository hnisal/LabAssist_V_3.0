using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabAssist_V_3._0.Data;
using LabAssist_V_3._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace LabAssist_V_3._0.Controllers
{
    [Authorize]
    public class DashboardsController : Controller
    {
        private readonly LabAssistDbContext _context;

        public DashboardsController(LabAssistDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Dashboards
        public async Task<IActionResult> Index()
        {
            var invoiceToChart = _context.Invoice.Include(j => j.Job);
            return View(await invoiceToChart.ToListAsync());
        }

        
    }
}
