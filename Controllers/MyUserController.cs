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
    public class MyUserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
              return _context.MyUser != null ? 
                          View(await _context.MyUser.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Users'  is null.");
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MyUser == null)
            {
                return NotFound();
            }

            var users = await _context.MyUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }
        
        //

        //nepouzivat Create, bude vytvoren pri registraci, puoze ho nechat uzivatele editovat

        //
        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SurName,BirthDate,Age,City,Street,ReferenceNumber,TelephoneNumber,Email")] MyUser users)
        {
            if (ModelState.IsValid)
            {
                _context.Add(users);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        //

        //po registraci dat uzivateli vypsat i MyUsers hodnoty
        //osetrit aby bez vyplnenych hodnot se nemohl prihlasit, po prihlaseni zkontrolat vyplneni a pripadne mu to dat vyplnit
        //kontrolovat vyplneni pri nove Insurence a InsurenceEvent

        //

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MyUser == null)
            {
                return NotFound();
            }

            var users = await _context.MyUser.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        public async Task<IActionResult> EditClient(int? id)
        {
            if (id == null || _context.MyUser == null)
            {
                return NotFound();
            }

            var users = await _context.MyUser.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SurName,BirthDate,Age,City,Street,ReferenceNumber,TelephoneNumber,Email")] MyUser users)
        {
            if (id != users.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ClientZone", "Account");
            }
            return View(users);
        }


        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MyUser == null)
            {
                return NotFound();
            }

            var users = await _context.MyUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MyUser == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Users'  is null.");
            }
            var users = await _context.MyUser.FindAsync(id);
            if (users != null)
            {
                _context.MyUser.Remove(users);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersExists(int id)
        {
          return (_context.MyUser?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
