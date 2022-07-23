using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CareHome.Data;
using CareHome.Models;

namespace CareHome.Views.Quaifications
{
    public class DeleteModel : PageModel
    {
        private readonly CareHome.Data.CareHomeContext _context;

        public DeleteModel(CareHome.Data.CareHomeContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Qualifications Qualifications { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Qualifications == null)
            {
                return NotFound();
            }

            var qualifications = await _context.Qualifications.FirstOrDefaultAsync(m => m.QualificationsId == id);

            if (qualifications == null)
            {
                return NotFound();
            }
            else 
            {
                Qualifications = qualifications;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Qualifications == null)
            {
                return NotFound();
            }
            var qualifications = await _context.Qualifications.FindAsync(id);

            if (qualifications != null)
            {
                Qualifications = qualifications;
                _context.Qualifications.Remove(Qualifications);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
