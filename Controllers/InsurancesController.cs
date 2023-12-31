﻿using System;
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
            var uzivatel = await _context.MyUser.SingleAsync(item => item.Email == User.Identity.Name);

            var insurances = from u in _context.Insurance
                             where u.MyUser.Id == uzivatel.Id
                             select u; 

            return View(insurances);
        }

        // GET: Insurance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Insurance == null)
            {
                return NotFound();
            }

            var insurance = await _context.Insurance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insurance == null)
            {
                return NotFound();
            }

            return View(insurance);
        }

        //

        //before create check fill all data and get user backto fill before he can create insurance
        //checking it eve with login

        //

        // GET: Insurance/Create
        public IActionResult CreateCestovni()
        {
            if (User.Identity?.Name != null)
            {
                var uzivatel = _context.MyUser?.Single(item => item.Email == User.Identity.Name);

                if (uzivatel?.Name.Length <= 1)
                {
                    return RedirectToAction("Edit", "MyUser", new { uzivatel.Id });
                }
                else
                {
                    return View();
                }
            }

            return View();
        }

        public IActionResult CreateMajetku()
        {
            if (User.Identity?.Name != null)
            {
                var uzivatel = _context.MyUser?.Single(item => item.Email == User.Identity.Name);

                if (uzivatel?.Name.Length <= 1)
                {
                    return RedirectToAction("Edit", "MyUser", new { uzivatel.Id });
                }
                else
                {
                    return View();
                }
            }

            return View();
        }
        public IActionResult CreateVozidel()
        {
            if (User.Identity?.Name != null)
            {
                var uzivatel = _context.MyUser?.Single(item => item.Email == User.Identity.Name);

                if (uzivatel?.Name.Length <= 1)
                {
                    return RedirectToAction("Edit", "MyUser", new { uzivatel.Id });
                }
                else
                {
                    return View();
                }
            }

            return View();
        }


        // POST: Insurance/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContractType,ContractNumber,MonthPayment,Principal,Validity")] Insurance insurance)
        {

            var user = _context.MyUser?.Single(item => item.Email == User.Identity.Name); 

            if (ModelState.IsValid)
            {
                insurance.MyUser = user;
                _context.Add(insurance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insurance);
        }

        // GET: Insurance/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Insurance == null)
            {
                return NotFound();
            }

            var insurance = await _context.Insurance.FindAsync(id);
            if (insurance == null)
            {
                return NotFound();
            }
            return View(insurance);
        }

        // POST: Insurance/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContractType,ContractNumber,MonthPayment,Principal,Validity")] Insurance insurance)
        {
            if (id != insurance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insurance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsurancesExists(insurance.Id))
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
            return View(insurance);
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
