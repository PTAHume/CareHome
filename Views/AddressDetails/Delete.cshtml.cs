using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CareHome.Data;
using CareHome.Models;

namespace CareHome.Views.AddressDetails
{
    public class DeleteModel : PageModel
    {
        private readonly CareHome.Data.CareHomeContext _context;

        public DeleteModel(CareHome.Data.CareHomeContext context)
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
            else
            {
                AddressDetails = addressdetails;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AddressDetails == null)
            {
                return NotFound();
            }
            var addressdetails = await _context.AddressDetails.FindAsync(id);

            if (addressdetails != null)
            {
                AddressDetails = addressdetails;
                _context.AddressDetails.Remove(AddressDetails);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
