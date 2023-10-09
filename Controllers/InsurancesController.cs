using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InsurenceWebApp.Data;
using InsurenceWebApp.Models;

namespace InsurenceWebApp.Controllers
{
    public class InsurancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InsurancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Insurances
        public async Task<IActionResult> Index()
        {
              return _context.Insurances != null ? 
                          View(await _context.Insurances.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Insurances'  is null.");
        }

        // GET: Insurances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Insurances == null)
            {
                return NotFound();
            }

            var insurances = await _context.Insurances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insurances == null)
            {
                return NotFound();
            }

            return View(insurances);
        }

        // GET: Insurances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insurances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContractNumber,MonthPayment,Principal,Validity")] Insurances insurances)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insurances);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insurances);
        }

        // GET: Insurances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Insurances == null)
            {
                return NotFound();
            }

            var insurances = await _context.Insurances.FindAsync(id);
            if (insurances == null)
            {
                return NotFound();
            }
            return View(insurances);
        }

        // POST: Insurances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContractNumber,MonthPayment,Principal,Validity")] Insurances insurances)
        {
            if (id != insurances.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insurances);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsurancesExists(insurances.Id))
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
            return View(insurances);
        }

        // GET: Insurances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Insurances == null)
            {
                return NotFound();
            }

            var insurances = await _context.Insurances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insurances == null)
            {
                return NotFound();
            }

            return View(insurances);
        }

        // POST: Insurances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Insurances == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Insurances'  is null.");
            }
            var insurances = await _context.Insurances.FindAsync(id);
            if (insurances != null)
            {
                _context.Insurances.Remove(insurances);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsurancesExists(int id)
        {
          return (_context.Insurances?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
