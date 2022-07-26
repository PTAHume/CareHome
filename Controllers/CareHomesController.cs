using System;
using System.Linq;
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
            var careHomeContext = _context.CareHomes.Include(c => c.AddressDetails).Include(c => c.ContactInfo);
            return View(await careHomeContext.ToListAsync());
        }

        // GET: CareHomes/Details/5
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null || _context.CareHomes == null)
            {
                return NotFound();
            }

            var careHomes = await _context.CareHomes
                .Include(c => c.AddressDetails)
                .Include(c => c.ContactInfo)
                .FirstOrDefaultAsync(m => m.CareHomesId == Id);
            if (careHomes == null)
            {
                return NotFound();
            }

            return View(careHomes);
        }

        // GET: CareHomes/Create
        public IActionResult Create()
        {
            ViewData["AddressDetailsId"] = new SelectList(_context.AddressDetails, "AddressDetailsId", "NumberStreetName");
            ViewData["ContactDetailsId"] = new SelectList(_context.ContactDetails, "ContactDetailsId", "ContactName");


            CareHomes CareHome = new()
            {
                AddressDetails = new CareHome.Models.AddressDetails(),
                ContactInfo = new CareHome.Models.ContactDetails()
            };

            return View(CareHome);
        }

        // POST: CareHomes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //
        public async Task<IActionResult> Create([Bind(include: "CareHomes, Name,AddressDetails, ContactInfo")] CareHomes careHomes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(careHomes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressDetailsId"] = new SelectList(_context.AddressDetails, "AddressDetailsId", "NumberStreetName", careHomes.AddressDetailsId);
            ViewData["ContactDetailsId"] = new SelectList(_context.ContactDetails, "ContactDetailsId", "ContactName", careHomes.ContactDetailsId);
            return View(careHomes);
        }

        // GET: CareHomes/Edit/5
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null || _context.CareHomes == null)
            {
                return NotFound();
            }

            CareHomes careHomes = await _context.CareHomes.FindAsync(Id);
            if (careHomes == null)
            {
                return NotFound();
            }
            careHomes.AddressDetails = await _context.AddressDetails.FindAsync(careHomes.AddressDetailsId);
            careHomes.ContactInfo = await _context.ContactDetails.FindAsync(careHomes.ContactDetailsId);

            ViewData["AddressDetailsId"] = new SelectList(_context.AddressDetails, "AddressDetailsId", "NumberStreetName", careHomes.AddressDetailsId);
            ViewData["ContactDetailsId"] = new SelectList(_context.ContactDetails, "ContactDetailsId", "ContactName", careHomes.ContactDetailsId);
            return View(careHomes);
        }

        // POST: CareHomes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("CareHomesId,Name,AddressDetails,ContactInfo,AddressDetailsId, ContactDetailsId")] CareHomes careHomes)
        {
            if (Id != careHomes.CareHomesId)
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
            ViewData["AddressDetailsId"] = new SelectList(_context.AddressDetails, "AddressDetailsId", "NumberStreetName", careHomes.AddressDetailsId);
            ViewData["ContactDetailsId"] = new SelectList(_context.ContactDetails, "ContactDetailsId", "ContactName", careHomes.ContactDetailsId);
            return View(careHomes);
        }

        // GET: CareHomes/Delete/5
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || _context.CareHomes == null)
            {
                return NotFound();
            }

            var careHomes = await _context.CareHomes
                .Include(c => c.AddressDetails)
                .Include(c => c.ContactInfo)
                .FirstOrDefaultAsync(m => m.CareHomesId == Id);
            if (careHomes == null)
            {
                return NotFound();
            }

            return View(careHomes);
        }

        // POST: CareHomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            if (_context.CareHomes == null)
            {
                return Problem("Entity set 'CareHomeContext.CareHomes'  is null.");
            }


            if (careHomes != null)
            {
                AddressDetails address = await _context.AddressDetails
                .Include(s => s.CareHomes)
                .Where(s => s.CareHomes.CareHomesId == Id).FirstAsync();
                ContactDetails contactInfo = await _context.ContactDetails
                    .Include(s => s.CareHomes)
                    .Where(s => s.CareHomes.CareHomesId == Id).FirstAsync();
                CareHomes careHomes = await _context.CareHomes
                    .Where(x => x.CareHomesId == Id).FirstAsync();
                List<Staff> staff = await _context.Staff
                    .Include(s => s.AddressDetails)
                    .Include(s => s.ContactInfo)
                    .Where(x => x.CareHomesId == Id).ToListAsync();
                List<Qualifications> qualifications = await _context.Qualifications
                    .Include(s => s.Staff)
                    .Include(s => s.Staff.CareHomes)
                    .Where(x => x.Staff.CareHomesId == Id).ToListAsync();
                List<AddressDetails> address2 = await _context.Staff
                    .Include(s => s.AddressDetails)
                    .Where(x => x.CareHomesId == Id)
                    .Select(s => s.AddressDetails).ToListAsync();
                List<ContactDetails> contact2 = await _context.Staff
                .Include(s => s.ContactInfo)
                .Where(x => x.CareHomesId == Id)
                .Select(s => s.ContactInfo).ToListAsync();


                _context.Qualifications.RemoveRange(qualifications);
                _context.ContactDetails.RemoveRange(contact2);
                _context.AddressDetails.RemoveRange(address2);
                _context.Staff.RemoveRange(staff);
                _context.ContactDetails.Remove(contactInfo);
                _context.AddressDetails.Remove(address);
                _context.CareHomes.Remove(careHomes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareHomesExists(int Id)
        {
            return (_context.CareHomes?.Any(e => e.CareHomesId == Id)).GetValueOrDefault();
        }
    }
}
