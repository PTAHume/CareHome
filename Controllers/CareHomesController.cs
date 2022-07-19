using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareHome.Data;
using CareHome.Models;

namespace CareHome.Controllers
{
    public class CareHomesController : Controller
    {
        private readonly CareHomeContext _context;

        public CareHomesController(CareHomeContext context)
        {
            _context = context;
        }

        // GET: CareHomes
        public async Task<IActionResult> Index()
        {
            return _context.CareHomes != null ?
                        View(await _context.CareHomes.ToListAsync()) :
                        Problem("Entity set 'CareHomeContext.CareHomes'  is null.");
        }

        // GET: CareHomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CareHomes == null)
            {
                return NotFound();
            }

            var careHomes = await _context.CareHomes
                .FirstOrDefaultAsync(m => m.CareHomesId == id);
            if (careHomes == null)
            {
                return NotFound();
            }

            return View(careHomes);
        }

        // GET: CareHomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CareHomes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CareHomesId,Name,ContactName,ContactNumber")] CareHomes careHomes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(careHomes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(careHomes);
        }

        // GET: CareHomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CareHomes == null)
            {
                return NotFound();
            }

            var careHomes = await _context.CareHomes.FindAsync(id);
            if (careHomes == null)
            {
                return NotFound();
            }
            return View(careHomes);
        }

        // POST: CareHomes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CareHomesId,Name,ContactName,ContactNumber")] CareHomes careHomes)
        {
            if (id != careHomes.CareHomesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(careHomes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareHomesExists(careHomes.CareHomesId))
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
            return View(careHomes);
        }

        // GET: CareHomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CareHomes == null)
            {
                return NotFound();
            }

            var careHomes = await _context.CareHomes
                .FirstOrDefaultAsync(m => m.CareHomesId == id);
            if (careHomes == null)
            {
                return NotFound();
            }

            return View(careHomes);
        }

        // POST: CareHomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CareHomes == null)
            {
                return Problem("Entity set 'CareHomeContext.CareHomes'  is null.");
            }
            var careHomes = await _context.CareHomes.FindAsync(id);
            if (careHomes != null)
            {
                _context.CareHomes.Remove(careHomes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareHomesExists(int id)
        {
            return (_context.CareHomes?.Any(e => e.CareHomesId == id)).GetValueOrDefault();
        }
    }
}
