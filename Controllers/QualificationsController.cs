﻿using CareHome.Data;
using CareHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareHome.Controllers
{
    public class QualificationsController : Controller
    {
        private readonly CareHomeContext _context;

        public QualificationsController(CareHomeContext context)
        {
            _context = context;
        }

        // GET: Qualifications
        public async Task<IActionResult> Index(int Id)
        {
            if (_context.Qualifications == null)
            {
                return Problem("Entity set 'CareHomeContext.Qualifications'  is null.");
            }

            if (await _context.Qualifications.AnyAsync(x => x.StaffId == Id))
            {
                ViewData["id"] = Id;
                return View(await _context.Qualifications.Include(s => s.Staff).Where(x => x.StaffId == Id).ToListAsync());
            }
            else
            {
                ViewData["id"] = 0;
                return View(new List<Qualifications>() { new Qualifications() { StaffId = Id, Staff = _context.Staff.First(x => x.StaffId == Id) } });
            }
        }

        // GET: Qualifications/Details/5
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null || _context.Qualifications == null)
            {
                return NotFound();
            }

            var qualifications = await _context.Qualifications.Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.QualificationsId == Id);
            if (qualifications == null)
            {
                return NotFound();
            }

            return View(qualifications);
        }

        // GET: Qualifications/Create
        public IActionResult Create(int Id)
        {
            var staff = _context.Staff.Include(s => s.CareHomes).First(x => x.StaffId == Id);

            return View(new Qualifications() { StaffId = staff.StaffId, Staff = staff });
        }

        // POST: Qualifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QualificationsId,QualificationType,Name,Grade,InstitutionalName,AttainmentDate,StaffId,Staff")] Qualifications qualifications)
        {
            qualifications.Staff = _context.Staff.Include(s => s.CareHomes).First(x => x.StaffId == qualifications.StaffId);

            if (ModelState.IsValid)
            {
                _context.Add(qualifications);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { Id = qualifications.StaffId });
            }

            return View(qualifications);
        }

        // GET: Qualifications/Edit/5
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null || _context.Qualifications == null)
            {
                return NotFound();
            }

            var qualifications = await _context.Qualifications.Include(s => s.Staff).FirstOrDefaultAsync(x => x.QualificationsId == Id);
            if (qualifications == null)
            {
                return NotFound();
            }
            return View(qualifications);
        }

        // POST: Qualifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("QualificationsId,QualificationType,Name,Grade,InstitutionalName,AttainmentDate,StaffId")] Qualifications qualifications)
        {
            if (Id != qualifications.QualificationsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qualifications);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QualificationsExists(qualifications.QualificationsId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { Id = qualifications.StaffId });
            }

            return View(await _context.Qualifications.Include(s => s.Staff).Include(s => s.Staff.CareHomes).FirstOrDefaultAsync());
        }

        // GET: Qualifications/Delete/5
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || _context.Qualifications == null)
            {
                return NotFound();
            }

            var qualifications = await _context.Qualifications.Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.QualificationsId == Id);
            if (qualifications == null)
            {
                return NotFound();
            }

            return View(qualifications);
        }

        // POST: Qualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            if (_context.Qualifications == null)
            {
                return Problem("Entity set 'CareHomeContext.Qualifications'  is null.");
            }
            var qualifications = await _context.Qualifications.FindAsync(Id);
            if (qualifications != null)
            {
                _context.Qualifications.Remove(qualifications);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { Id = qualifications.StaffId });
        }

        private bool QualificationsExists(int Id)
        {
            return (_context.Qualifications?.Any(e => e.QualificationsId == Id)).GetValueOrDefault();
        }
    }
}