using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CareHome.Models;

namespace CareHome.Data
{
    public class CareHomeContext : DbContext
    {
        public CareHomeContext (DbContextOptions<CareHomeContext> options)
            : base(options)
        {
        }

        public DbSet<CareHome.Models.Staff> Staff { get; set; } = default!;

        public DbSet<CareHome.Models.CareHomes>? CareHomes { get; set; }

        public DbSet<CareHome.Models.Departments>? Departments { get; set; }

        public DbSet<CareHome.Models.JobTitles>? JobTitles { get; set; }
    }
}
