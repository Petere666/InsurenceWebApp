using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InsurenceWebApp.Data;
using InsurenceWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace InsurenceWebApp.Controllers
{
    public class InsurancesController : Controller
    {
        private readonly ApplicationDbContext _context; 

        public InsurancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Insurance
        public async Task<IActionResult> Index()
        {
              return _context.Insurance != null ? 
                          View(await _context.Insurance.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Insurance'  is null.");
        }

        // GET: Insurance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Insurance == null)
            {
                return NotFound();
            }

            var insurances = await _context.Insurance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insurances == null)
            {
                return NotFound();
            }

            return View(insurances);
        }

        // GET: Insurance/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insurance/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(String MyUser, [Bind("Id,ContractNumber,MonthPayment,Principal,Validity")] Insurance insurances)
        {
            var user = _context.MyUser.Single(item => item.Email == MyUser);

            if (ModelState.IsValid)
            {
                insurances.MyUser = user;
                _context.Add(insurances);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insurances);
        }

        // GET: Insurance/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Insurance == null)
            {
                return NotFound();
            }

            var insurances = await _context.Insurance.FindAsync(id);
            if (insurances == null)
            {
                return NotFound();
            }
            return View(insurances);
        }

        // POST: Insurance/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContractNumber,MonthPayment,Principal,Validity")] Insurance insurances)
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

        // GET: Insurance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Insurance == null)
            {
                return NotFound();
            }

            var insurances = await _context.Insurance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insurances == null)
            {
                return NotFound();
            }

            return View(insurances);
        }

        // POST: Insurance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Insurance == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Insurance'  is null.");
            }
            var insurances = await _context.Insurance.FindAsync(id);
            if (insurances != null)
            {
                _context.Insurance.Remove(insurances);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsurancesExists(int id)
        {
          return (_context.Insurance?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
