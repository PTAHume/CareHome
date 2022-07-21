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
    public class IndexModel : PageModel
    {
        private readonly CareHome.Data.CareHomeContext _context;

        public IndexModel(CareHome.Data.CareHomeContext context)
        {
            _context = context;
        }

        public IList<CareHome.Models.AddressDetails> AddressDetails { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AddressDetails != null)
            {
                AddressDetails = await _context.AddressDetails.ToListAsync();
            }
        }
    }
}
