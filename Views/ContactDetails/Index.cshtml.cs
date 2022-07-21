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
    public class IndexModel : PageModel
    {
        private readonly CareHome.Data.CareHomeContext _context;

        public IndexModel(CareHome.Data.CareHomeContext context)
        {
            _context = context;
        }

        public IList<CareHome.Models.ContactDetails> ContactDetails { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ContactDetails != null)
            {
                ContactDetails = await _context.ContactDetails.ToListAsync();
            }
        }
    }
}
