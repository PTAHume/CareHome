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

namespace CareHome.Views.ContactDetails
{
    public class EditModel : PageModel
    {
        private readonly CareHome.Data.CareHomeContext _context;

        public EditModel(CareHome.Data.CareHomeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CareHome.Models.ContactDetails ContactDetails { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ContactDetails == null)
            {
                return NotFound();
            }

            var contactdetails = await _context.ContactDetails.FirstOrDefaultAsync(m => m.ContactDetailsId == id);
            if (contactdetails == null)
            {
                return NotFound();
            }
            ContactDetails = contactdetails;
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

            _context.Attach(ContactDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactDetailsExists(ContactDetails.ContactDetailsId))
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

        private bool ContactDetailsExists(int id)
        {
            return (_context.ContactDetails?.Any(e => e.ContactDetailsId == id)).GetValueOrDefault();
        }
    }
}
