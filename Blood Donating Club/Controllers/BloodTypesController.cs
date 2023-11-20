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
    public class BloodTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BloodTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BloodTypes
        public async Task<IActionResult> Index()
        {
            return _context.BloodType != null ?
                        View(await _context.BloodType.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.BloodType'  is null.");
        }

        // GET: BloodTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BloodType == null)
            {
                return NotFound();
            }

            var bloodType = await _context.BloodType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodType == null)
            {
                return NotFound();
            }

            return View(bloodType);
        }

        // GET: BloodTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BloodTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] BloodType bloodType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bloodType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bloodType);
        }

        // GET: BloodTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BloodType == null)
            {
                return NotFound();
            }

            var bloodType = await _context.BloodType.FindAsync(id);
            if (bloodType == null)
            {
                return NotFound();
            }
            return View(bloodType);
        }

        // POST: BloodTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] BloodType bloodType)
        {
            if (id != bloodType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bloodType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloodTypeExists(bloodType.Id))
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
            return View(bloodType);
        }

        // GET: BloodTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BloodType == null)
            {
                return NotFound();
            }

            var bloodType = await _context.BloodType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodType == null)
            {
                return NotFound();
            }

            return View(bloodType);
        }

        // POST: BloodTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BloodType == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BloodType'  is null.");
            }
            var bloodType = await _context.BloodType.FindAsync(id);
            if (bloodType != null)
            {
                _context.BloodType.Remove(bloodType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloodTypeExists(int id)
        {
            return (_context.BloodType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
