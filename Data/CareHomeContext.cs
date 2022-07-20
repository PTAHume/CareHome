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
        public CareHomeContext(DbContextOptions<CareHomeContext> options)
            : base(options)
        {
        }

        public DbSet<AddressDetails> AddressDetails { get; set; }
        public DbSet<CareHomes> CareHomes { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<EthnicityGroups> EthnicityGroups { get; set; }
        public DbSet<EthnicityGroups> EthnicityTypes { get; set; }
        public DbSet<GenderTypes> GenderTypes { get; set; }
        public DbSet<JobTitles> JobTitles { get; set; }
        public DbSet<Staff> Staff { get; set; }
    }
}
