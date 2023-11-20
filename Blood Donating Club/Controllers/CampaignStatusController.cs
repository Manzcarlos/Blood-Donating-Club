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
    public class CampaignStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CampaignStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CampaignStatus
        public async Task<IActionResult> Index()
        {
              return _context.CampaignStatus != null ? 
                          View(await _context.CampaignStatus.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CampaignStatus'  is null.");
        }

        // GET: CampaignStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CampaignStatus == null)
            {
                return NotFound();
            }

            var campaignStatus = await _context.CampaignStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campaignStatus == null)
            {
                return NotFound();
            }

            return View(campaignStatus);
        }

        // GET: CampaignStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CampaignStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CampaignStatus campaignStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campaignStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campaignStatus);
        }

        // GET: CampaignStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CampaignStatus == null)
            {
                return NotFound();
            }

            var campaignStatus = await _context.CampaignStatus.FindAsync(id);
            if (campaignStatus == null)
            {
                return NotFound();
            }
            return View(campaignStatus);
        }

        // POST: CampaignStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CampaignStatus campaignStatus)
        {
            if (id != campaignStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campaignStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampaignStatusExists(campaignStatus.Id))
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
            return View(campaignStatus);
        }

        // GET: CampaignStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CampaignStatus == null)
            {
                return NotFound();
            }

            var campaignStatus = await _context.CampaignStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campaignStatus == null)
            {
                return NotFound();
            }

            return View(campaignStatus);
        }

        // POST: CampaignStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CampaignStatus == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CampaignStatus'  is null.");
            }
            var campaignStatus = await _context.CampaignStatus.FindAsync(id);
            if (campaignStatus != null)
            {
                _context.CampaignStatus.Remove(campaignStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampaignStatusExists(int id)
        {
          return (_context.CampaignStatus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
