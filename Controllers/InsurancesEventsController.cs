using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InsurenceWebApp.Data;
using InsurenceWebApp.Models;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.Logging;
using SQLitePCL;

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
            var uzivatel = await _context.MyUser.SingleAsync(item => item.Email == User.Identity.Name);

            var myinsurances = (from u in _context.Insurance
                               where u.MyUser.Id == uzivatel.Id
                               select u.Id).ToList();

            var myEvents = from e in _context.InsurancesEvents
                           where myinsurances.Contains(e.InsurancesId)
                           select e;

            //ViewBag.Event = myEvents;

            return View(myEvents);

            //var filterEventAndInsurance = _context.InsurancesEvents.IntersectBy(_context.Insurance.Where(i=>i.MyUser.Id==uzivatel.Id),e => e.Insurance);

            //ViewBag.Event = filterEventAndInsurance;

            //var insurances = (from u in _context.Insurance
            //                 where u.MyUser.Id == uzivatel.Id
            //                 select u.MyEvents).ToList();

            //var myEvents = _context.InsurancesEvents.Where(e=>insurances.Contains(e.Insurance)).ToList();

            //InsurancesEvents SelectedInsurancesEvents = _context.InsurancesEvents.Include()



            //List<InsurancesEvents> myEvents = new List<InsurancesEvents>();

            //foreach(var insurance in insurances)
            //{
            //    var oneEvent = from e in _context.InsurancesEvents
            //                   where e.InsurancesId == insurance
            //                   select e;
            //    myEvents.Add(oneEvent);
            //}

            //var myEvents = from e in _context.InsurancesEvents
            //               where e.InsurancesId == (_context.Insurance.FirstOrDefault(item => item.Id == uzivatel.Id))
            //               select e;



            //var myEvents = await _context.InsurancesEvents.FirstOrDefaultAsync(item => item.InsurancesId == insurances).ToList();

            //insurances.ToList();

            //var myEvents = from e in _context.InsurancesEvents
            //               where e.InsurancesId == insurances
            //               select e;

            //return _context.InsurancesEvents != null ?
            //              View(await _context.InsurancesEvents.ToListAsync()) :
            //              Problem("Entity set 'ApplicationDbContext.InsurancesEvents'  is null.");

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
        public async Task<IActionResult> Create()
        {
            var uzivatel = await _context.MyUser.SingleAsync(item => item.Email == User.Identity.Name);

            var insurances = from u in _context.Insurance
                             where u.MyUser.Id == uzivatel.Id
                             select u;

            var eventNumber = _context.InsurancesEvents?.Count(m => m.Id != 0);

            ViewBag.EventNumber = eventNumber + 1;
            ViewBag.Insurance = insurances;
            
            return View();
        }

        // POST: InsurancesEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // it was useing user email as id, so i put event number as id and now its table generating proper id, dont know why
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsurancesEvents model,[Bind("InsurancesId,EventNumber,DamageAmount,DamageDescription")] InsurancesEvents insurancesEvents)
        {
            var insurance = await _context.Insurance.FirstOrDefaultAsync(u => u.Id == model.InsurancesId);
            insurancesEvents.ContractNumber = insurance.ContractNumber;
            

            if (ModelState.IsValid)   
            {
                _context.Add(insurancesEvents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AccountController.ClientZone), "Account");
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
