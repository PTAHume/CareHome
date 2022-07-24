using CareHome.Data;
using CareHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;

namespace CareHome.Controllers
{
    public class StaffController : Controller
    {
        private readonly CareHomeContext _context;

        public StaffController(CareHomeContext context)
        {
            _context = context;

        }

        // GET: Staffs
        public async Task<IActionResult> Index(int Id)
        {
            var careHomeContext = _context.Staff.Where(x => x.CareHomesId == Id)
                .Include(s => s.AddressDetails)
                .Include(s => s.ContactInfo)
                .Include(s => s.Department)
                .Include(s => s.CareHomes)
                .Include(s => s.Qualifications)
                .Include(s => s.Department)
                .Include(s => s.JobTitle)
                .Include(s => s.Ethnicity)
                .Include(s => s.Gender)
                .Include(s => s.JobTitle);

            List<Staff> staffData = careHomeContext.ToList();

            if (!staffData.Any(x => x.CareHomesId == Id))
            {
                ViewData["Id"] = 0;
                staffData.Add(new Staff() { CareHomesId = Id, CareHomes = new CareHomes() { CareHomesId = Id } });
            }
            else
            {
                ViewData["Id"] = Id;
            }

            return View(staffData);
        }

        // GET: Staffs/Details/5
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null || _context.Staff == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .Include(s => s.CareHomes)
                .Include(s => s.AddressDetails)
                .Include(s => s.ContactInfo)
                .Include(s => s.Department)
                .Include(s => s.Qualifications)
                .Include(s => s.Ethnicity)
                .Include(s => s.Gender)
                .Include(s => s.JobTitle)
                .FirstOrDefaultAsync(m => m.StaffId == Id);

            if (staff == null)
            {
                return NotFound();
            }


            return View(staff);
        }
        public JsonResult GetJobList(int DepartmentId)
        {
            List<SelectListItem> jobList = new List<SelectListItem> { new SelectListItem() { Text = string.Empty, Value = "-1", Selected = true } };
            jobList.AddRange(_context!.JobTitles.Where(x => x.Departments.DepartmentId == DepartmentId)
                .Select(item => new SelectListItem { Text = item.Title, Value = item.JobTitlesId.ToString() }).ToList());

            return Json(jobList);
        }

        // GET: Staffs/Create
        public IActionResult Create(int Id)
        {
            List<SelectListItem> DepartmentList = new List<SelectListItem>();
            DepartmentList.Add(new SelectListItem { Text = string.Empty, Value = "-1" });
            DepartmentList.AddRange(_context.Departments.Select(x => new SelectListItem { Text = x.Name, Value = x.DepartmentId.ToString() }));

            ViewData["AddressDetailsId"] = new SelectList(_context.AddressDetails, "AddressDetailsId", "NumberStreetName");
            ViewData["ContactDetailsId"] = new SelectList(_context.ContactDetails, "ContactDetailsId", "ContactName");
            ViewData["DepartmentId"] = DepartmentList;
            ViewData["EthnicityGroupsId"] = new SelectList(_context.EthnicityGroups, "EthnicityGroupsId", "GroupName");
            ViewData["GenderTypesId"] = new SelectList(_context.GenderTypes, "GenderTypesId", "Gender");
            ViewData["JobTitlesId"] = new SelectList(_context.JobTitles, "JobTitlesId", "Description");
            ViewData["CareHomesId"] = new SelectList(_context.CareHomes.Where(x => x.CareHomesId == Id), "CareHomesId", "Name");

            Staff StaffData = new Staff()
            {
                ContactDetailsId = 0,
                AddressDetailsId = 0,
                CareHomesId = Id,
                Qualifications = new List<Qualifications>(),
                CareHomes = new CareHomes() { CareHomesId = Id },
                Ethnicity = new EthnicityGroups(),
                Gender = new GenderTypes(),
                JobTitle = new JobTitles(),
                Department = new Departments(),
            };

            return View(StaffData);
        }



        // POST: Qualifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("QualificationsId,QualificationType,Name,Grade,InstitutionalName,AttainmentDate")] Qualifications qualifications)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qualifications);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // return View(qualifications);

            return RedirectToAction("Create", "Staff");
        }


        // POST: Staffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffId,Forename,MiddleNames,LastName,GenderTypesId,Gender,AddressDetails,CareHomes, ContactInfo,EthnicityGroupsId,Ethnicity,DOB,DepartmentId,Department,JobTitlesId,Salary,CareHomesId")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { Id = staff.CareHomesId });
            }

            ViewData["AddressDetailsId"] = new SelectList(_context.AddressDetails, "AddressDetailsId", "NumberStreetName", staff.AddressDetailsId);
            ViewData["ContactDetailsId"] = new SelectList(_context.ContactDetails, "ContactDetailsId", "ContactName", staff.ContactDetailsId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name", staff.DepartmentId);
            ViewData["EthnicityGroupsId"] = new SelectList(_context.EthnicityGroups, "EthnicityGroupsId", "GroupName", staff.EthnicityGroupsId);
            ViewData["GenderTypesId"] = new SelectList(_context.GenderTypes, "GenderTypesId", "Gender", staff.GenderTypesId);
            ViewData["JobTitlesId"] = new SelectList(_context.JobTitles, "JobTitlesId", "Title");
            ViewData["CareHomesId"] = new SelectList(_context.CareHomes.Where(x => x.CareHomesId == staff.CareHomesId), "CareHomesId", "Name");

            return View(staff);
        }

        // GET: Staffs/Edit/5
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null || _context.Staff == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.Include(s => s.CareHomes).FirstOrDefaultAsync(x => x.StaffId == Id);
            if (staff == null)
            {
                return NotFound();
            }
            ViewData["JobTId"] = staff.JobTitlesId;
            ViewData["DepId"] = staff.DepartmentId;
            ViewData["AddressDetailsId"] = new SelectList(_context.AddressDetails, "AddressDetailsId", "NumberStreetName", staff.AddressDetailsId);
            ViewData["ContactDetailsId"] = new SelectList(_context.ContactDetails, "ContactDetailsId", "ContactName", staff.ContactDetailsId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name", staff.DepartmentId);
            ViewData["EthnicityGroupsId"] = new SelectList(_context.EthnicityGroups, "EthnicityGroupsId", "GroupName", staff.EthnicityGroupsId);
            ViewData["GenderTypesId"] = new SelectList(_context.GenderTypes, "GenderTypesId", "Gender", staff.GenderTypesId);
            ViewData["JobTitlesId"] = new SelectList(_context.JobTitles, "JobTitlesId", "Title", staff.JobTitlesId);
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("StaffId,Forename,MiddleNames,LastName,GenderTypesId,AddressDetailsId,ContactDetailsId,EthnicityGroupsId,DOB,DepartmentId,JobTitlesId,Salary,CareHomesId")] Staff staff)
        {
            if (Id != staff.StaffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.StaffId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { Id = staff.CareHomesId });
            }
            ViewData["AddressDetailsId"] = new SelectList(_context.AddressDetails, "AddressDetailsId", "NumberStreetName", staff.AddressDetailsId);
            ViewData["ContactDetailsId"] = new SelectList(_context.ContactDetails, "ContactDetailsId", "ContactName", staff.ContactDetailsId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Description", staff.DepartmentId);
            ViewData["EthnicityGroupsId"] = new SelectList(_context.EthnicityGroups, "EthnicityGroupsId", "GroupName", staff.EthnicityGroupsId);
            ViewData["GenderTypesId"] = new SelectList(_context.GenderTypes, "GenderTypesId", "Gender", staff.GenderTypesId);
            ViewData["JobTitlesId"] = new SelectList(_context.JobTitles, "JobTitlesId", "Description", staff.JobTitlesId);
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || _context.Staff == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .Include(s => s.CareHomes)
                .Include(s => s.AddressDetails)
                .Include(s => s.ContactInfo)
                .Include(s => s.Department)
                .Include(s => s.Ethnicity)
                .Include(s => s.Gender)
                .Include(s => s.JobTitle)
                .FirstOrDefaultAsync(m => m.StaffId == Id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            if (_context.Staff == null)
            {
                return Problem("Entity set 'CareHomeContext.Staff'  is null.");
            }
            var staff = await _context.Staff.FindAsync(Id);
            if (staff != null)
            {
                _context.Staff.Remove(staff);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { Id = staff.CareHomesId });
        }

        private bool StaffExists(int Id)
        {
            return (_context.Staff?.Any(e => e.StaffId == Id)).GetValueOrDefault();
        }
    }
}
