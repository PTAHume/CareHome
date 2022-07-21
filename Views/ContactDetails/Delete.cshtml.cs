using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CareHome.Data;
using CareHome.Models;

namespace CareHome.Views.ContactDetails
{
    public class DeleteModel : PageModel
    {
        private readonly CareHome.Data.CareHomeContext _context;

        public DeleteModel(CareHome.Data.CareHomeContext context)
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
            else
            {
                ContactDetails = contactdetails;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ContactDetails == null)
            {
                return NotFound();
            }
            var contactdetails = await _context.ContactDetails.FindAsync(id);

            if (contactdetails != null)
            {
                ContactDetails = contactdetails;
                _context.ContactDetails.Remove(ContactDetails);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
