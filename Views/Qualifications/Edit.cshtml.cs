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

namespace CareHome.Views.Quaifications
{
    public class EditModel : PageModel
    {
        private readonly CareHome.Data.CareHomeContext _context;

        public EditModel(CareHome.Data.CareHomeContext context)
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

            var qualifications =  await _context.Qualifications.FirstOrDefaultAsync(m => m.QualificationsId == id);
            if (qualifications == null)
            {
                return NotFound();
            }
            Qualifications = qualifications;
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

            _context.Attach(Qualifications).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QualificationsExists(Qualifications.QualificationsId))
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

        private bool QualificationsExists(int id)
        {
          return (_context.Qualifications?.Any(e => e.QualificationsId == id)).GetValueOrDefault();
        }
    }
}
