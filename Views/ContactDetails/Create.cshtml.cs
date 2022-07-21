using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CareHome.Data;
using CareHome.Models;

namespace CareHome.Views.ContactDetails
{
    public class CreateModel : PageModel
    {
        private readonly CareHome.Data.CareHomeContext _context;

        public CreateModel(CareHome.Data.CareHomeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CareHome.Models.ContactDetails ContactDetails { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.ContactDetails == null || ContactDetails == null)
            {
                return Page();
            }

            _context.ContactDetails.Add(ContactDetails);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
