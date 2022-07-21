using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareHome.Data;
using CareHome.Models;

namespace CareHome.Views.AddressDetails
{
    public class EditModel : PageModel
    {
        private readonly CareHome.Data.CareHomeContext _context;

        public EditModel(CareHome.Data.CareHomeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CareHome.Models.AddressDetails AddressDetails { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AddressDetails == null)
            {
                return NotFound();
            }

            var addressdetails = await _context.AddressDetails.FirstOrDefaultAsync(m => m.AddressDetailsId == id);
            if (addressdetails == null)
            {
                return NotFound();
            }
            AddressDetails = addressdetails;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AddressDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressDetailsExists(AddressDetails.AddressDetailsId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AddressDetailsExists(int id)
        {
            return (_context.AddressDetails?.Any(e => e.AddressDetailsId == id)).GetValueOrDefault();
        }
    }
}
