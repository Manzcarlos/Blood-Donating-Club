using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blood_Donating_Club.Data;
using Blood_Donating_Club.Models;

namespace Blood_Donating_Club.Controllers
{
    public class DonatingCentersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonatingCentersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DonatingCenters
        public async Task<IActionResult> Index()
        {
              return _context.DonatingCenter != null ? 
                          View(await _context.DonatingCenter.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DonatingCenter'  is null.");
        }

        // GET: DonatingCenters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DonatingCenter == null)
            {
                return NotFound();
            }

            var donatingCenter = await _context.DonatingCenter
                .FirstOrDefaultAsync(m => m.ID == id);
            if (donatingCenter == null)
            {
                return NotFound();
            }

            return View(donatingCenter);
        }

        // GET: DonatingCenters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DonatingCenters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Address,BusinessHours,PhoneNumber,ManagerName")] DonatingCenter donatingCenter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donatingCenter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donatingCenter);
        }

        // GET: DonatingCenters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DonatingCenter == null)
            {
                return NotFound();
            }

            var donatingCenter = await _context.DonatingCenter.FindAsync(id);
            if (donatingCenter == null)
            {
                return NotFound();
            }
            return View(donatingCenter);
        }

        // POST: DonatingCenters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address,BusinessHours,PhoneNumber,ManagerName")] DonatingCenter donatingCenter)
        {
            if (id != donatingCenter.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donatingCenter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonatingCenterExists(donatingCenter.ID))
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
            return View(donatingCenter);
        }

        // GET: DonatingCenters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DonatingCenter == null)
            {
                return NotFound();
            }

            var donatingCenter = await _context.DonatingCenter
                .FirstOrDefaultAsync(m => m.ID == id);
            if (donatingCenter == null)
            {
                return NotFound();
            }

            return View(donatingCenter);
        }

        // POST: DonatingCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DonatingCenter == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DonatingCenter'  is null.");
            }
            var donatingCenter = await _context.DonatingCenter.FindAsync(id);
            if (donatingCenter != null)
            {
                _context.DonatingCenter.Remove(donatingCenter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonatingCenterExists(int id)
        {
          return (_context.DonatingCenter?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
