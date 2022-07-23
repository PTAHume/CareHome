using CareHome.Data;
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
        public async Task<IActionResult> Index(int id)
        {
            if (_context.Qualifications == null)
            {
                return Problem("Entity set 'CareHomeContext.Qualifications'  is null.");
            }

            if (await _context.Qualifications.AnyAsync(x => x.StaffId == id))
            {
                ViewData["id"] = id;
                // QualificationsList.ForEach(x => x.Staff = _context!.Staff.First(x => x.StaffId == id));
                return View(await _context.Qualifications.Include(s => s.Staff).Where(x => x.StaffId == id).ToListAsync());
            }
            else
            {
                ViewData["id"] = 0;
                return View(new List<Qualifications>() { new Qualifications() { StaffId = id, Staff = _context.Staff.First(x => x.StaffId == id) } });
            }
        }

        // GET: Qualifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Qualifications == null)
            {
                return NotFound();
            }

            var qualifications = await _context.Qualifications.Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.QualificationsId == id);
            if (qualifications == null)
            {
                return NotFound();
            }

            return View(qualifications);
        }

        // GET: Qualifications/Create
        public IActionResult Create(int id)
        {
            var staffId = _context.Staff.First(x => x.StaffId == id).StaffId;

            return View(new Qualifications() { StaffId = staffId });
        }

        // POST: Qualifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QualificationsId,QualificationType,Name,Grade,InstitutionalName,AttainmentDate,StaffId")] Qualifications qualifications)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qualifications);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = qualifications.StaffId });
            }
            return View(qualifications);
        }

        // GET: Qualifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Qualifications == null)
            {
                return NotFound();
            }

            var qualifications = await _context.Qualifications.Include(s => s.Staff).FirstOrDefaultAsync(x => x.QualificationsId == id);
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
        public async Task<IActionResult> Edit(int id, [Bind("QualificationsId,QualificationType,Name,Grade,InstitutionalName,AttainmentDate")] Qualifications qualifications)
        {
            if (id != qualifications.QualificationsId)
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
                return RedirectToAction(nameof(Index));
            }
            return View(qualifications);
        }

        // GET: Qualifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Qualifications == null)
            {
                return NotFound();
            }

            var qualifications = await _context.Qualifications.Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.QualificationsId == id);
            if (qualifications == null)
            {
                return NotFound();
            }

            return View(qualifications);
        }

        // POST: Qualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Qualifications == null)
            {
                return Problem("Entity set 'CareHomeContext.Qualifications'  is null.");
            }
            var qualifications = await _context.Qualifications.FindAsync(id);
            if (qualifications != null)
            {
                _context.Qualifications.Remove(qualifications);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QualificationsExists(int id)
        {
            return (_context.Qualifications?.Any(e => e.QualificationsId == id)).GetValueOrDefault();
        }
    }
}