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
    public class JobTitlesController : Controller
    {
        private readonly CareHomeContext _context;

        public JobTitlesController(CareHomeContext context)
        {
            _context = context;
        }

        // GET: JobTitles
        public async Task<IActionResult> Index()
        {
              return _context.JobTitles != null ? 
                          View(await _context.JobTitles.ToListAsync()) :
                          Problem("Entity set 'CareHomeContext.JobTitles'  is null.");
        }

        // GET: JobTitles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JobTitles == null)
            {
                return NotFound();
            }

            var jobTitles = await _context.JobTitles
                .FirstOrDefaultAsync(m => m.JobTitlesId == id);
            if (jobTitles == null)
            {
                return NotFound();
            }

            return View(jobTitles);
        }

        // GET: JobTitles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobTitles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobTitlesId,Title,Description,DefaultSalary")] JobTitles jobTitles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobTitles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobTitles);
        }

        // GET: JobTitles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JobTitles == null)
            {
                return NotFound();
            }

            var jobTitles = await _context.JobTitles.FindAsync(id);
            if (jobTitles == null)
            {
                return NotFound();
            }
            return View(jobTitles);
        }

        // POST: JobTitles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobTitlesId,Title,Description,DefaultSalary")] JobTitles jobTitles)
        {
            if (id != jobTitles.JobTitlesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobTitles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobTitlesExists(jobTitles.JobTitlesId))
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
            return View(jobTitles);
        }

        // GET: JobTitles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.JobTitles == null)
            {
                return NotFound();
            }

            var jobTitles = await _context.JobTitles
                .FirstOrDefaultAsync(m => m.JobTitlesId == id);
            if (jobTitles == null)
            {
                return NotFound();
            }

            return View(jobTitles);
        }

        // POST: JobTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JobTitles == null)
            {
                return Problem("Entity set 'CareHomeContext.JobTitles'  is null.");
            }
            var jobTitles = await _context.JobTitles.FindAsync(id);
            if (jobTitles != null)
            {
                _context.JobTitles.Remove(jobTitles);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobTitlesExists(int id)
        {
          return (_context.JobTitles?.Any(e => e.JobTitlesId == id)).GetValueOrDefault();
        }
    }
}
