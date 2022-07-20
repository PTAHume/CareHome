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
    public class AddressDetailsController : Controller
    {
        private readonly CareHomeContext _context;

        public AddressDetailsController(CareHomeContext context)
        {
            _context = context;
        }

        // GET: AddressDetails
        public async Task<IActionResult> Index()
        {
              return _context.AddressDetails != null ? 
                          View(await _context.AddressDetails.ToListAsync()) :
                          Problem("Entity set 'CareHomeContext.AddressDetails'  is null.");
        }

        // GET: AddressDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AddressDetails == null)
            {
                return NotFound();
            }

            var addressDetails = await _context.AddressDetails
                .FirstOrDefaultAsync(m => m.AddressDetailsId == id);
            if (addressDetails == null)
            {
                return NotFound();
            }

            return View(addressDetails);
        }

        // GET: AddressDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddressDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddressDetailsId,NumberStreetName,Locality,Town,PostCode")] AddressDetails addressDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addressDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addressDetails);
        }

        // GET: AddressDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AddressDetails == null)
            {
                return NotFound();
            }

            var addressDetails = await _context.AddressDetails.FindAsync(id);
            if (addressDetails == null)
            {
                return NotFound();
            }
            return View(addressDetails);
        }

        // POST: AddressDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressDetailsId,NumberStreetName,Locality,Town,PostCode")] AddressDetails addressDetails)
        {
            if (id != addressDetails.AddressDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addressDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressDetailsExists(addressDetails.AddressDetailsId))
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
            return View(addressDetails);
        }

        // GET: AddressDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AddressDetails == null)
            {
                return NotFound();
            }

            var addressDetails = await _context.AddressDetails
                .FirstOrDefaultAsync(m => m.AddressDetailsId == id);
            if (addressDetails == null)
            {
                return NotFound();
            }

            return View(addressDetails);
        }

        // POST: AddressDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AddressDetails == null)
            {
                return Problem("Entity set 'CareHomeContext.AddressDetails'  is null.");
            }
            var addressDetails = await _context.AddressDetails.FindAsync(id);
            if (addressDetails != null)
            {
                _context.AddressDetails.Remove(addressDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressDetailsExists(int id)
        {
          return (_context.AddressDetails?.Any(e => e.AddressDetailsId == id)).GetValueOrDefault();
        }
    }
}
