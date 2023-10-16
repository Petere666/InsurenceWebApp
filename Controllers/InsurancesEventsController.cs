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
    public class InsurancesEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InsurancesEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InsurancesEvents
        public async Task<IActionResult> Index()
        {
              return _context.InsurancesEvents != null ? 
                          View(await _context.InsurancesEvents.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.InsurancesEvents'  is null.");
        }

        // GET: InsurancesEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InsurancesEvents == null)
            {
                return NotFound();
            }

            var insurancesEvents = await _context.InsurancesEvents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insurancesEvents == null)
            {
                return NotFound();
            }

            return View(insurancesEvents);
        }

        //

        //pridat kontrolu jestli existuje Insurance, mozne lze udelat na HTML
        //

        //

        // GET: InsurancesEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InsurancesEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContractNumber,EventNumber,DamageAmount,DamageDescription")] InsurancesEvents insurancesEvents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insurancesEvents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insurancesEvents);
        }

        // GET: InsurancesEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InsurancesEvents == null)
            {
                return NotFound();
            }

            var insurancesEvents = await _context.InsurancesEvents.FindAsync(id);
            if (insurancesEvents == null)
            {
                return NotFound();
            }
            return View(insurancesEvents);
        }

        // POST: InsurancesEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContractNumber,EventNumber,DamageAmount,DamageDescription")] InsurancesEvents insurancesEvents)
        {
            if (id != insurancesEvents.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insurancesEvents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsurancesEventsExists(insurancesEvents.Id))
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
            return View(insurancesEvents);
        }

        // GET: InsurancesEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InsurancesEvents == null)
            {
                return NotFound();
            }

            var insurancesEvents = await _context.InsurancesEvents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insurancesEvents == null)
            {
                return NotFound();
            }

            return View(insurancesEvents);
        }

        // POST: InsurancesEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InsurancesEvents == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InsurancesEvents'  is null.");
            }
            var insurancesEvents = await _context.InsurancesEvents.FindAsync(id);
            if (insurancesEvents != null)
            {
                _context.InsurancesEvents.Remove(insurancesEvents);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsurancesEventsExists(int id)
        {
          return (_context.InsurancesEvents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
