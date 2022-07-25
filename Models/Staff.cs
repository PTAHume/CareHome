using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class Staff
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffId { get; set; }

        [Required]
        [Display(Name = "First Names")]
        [Column(TypeName = "VARCHAR(256)")]
        [StringLength(256, MinimumLength = 2)]
        public string Forename { get; set; }

        [Display(Name = "Middle Names")]
        [Column(TypeName = "VARCHAR(256)")]
        [StringLength(256, MinimumLength = 2)]
        public string? MiddleNames { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [Column(TypeName = "VARCHAR(256)")]
        [StringLength(256, MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "Gender")]
        public int? GenderTypesId { get; set; }

        public GenderTypes? Gender { get; set; }

        [Display(Name = "Address")]
        public int? AddressDetailsId { get; set; }

        public AddressDetails? AddressDetails { get; set; }

        [Display(Name = " Contact Details")]
        public int? ContactDetailsId { get; set; }

        public ContactDetails? ContactInfo { get; set; }

        [Display(Name = "Ethnicity")]
        public int? EthnicityGroupsId { get; set; }

        public EthnicityGroups? Ethnicity { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }

        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }

        public Departments? Department { get; set; }

        [Display(Name = "Job Title")]
        public int? JobTitlesId { get; set; }

        public JobTitles? JobTitle { get; set; }

        [Column(TypeName = "DECIMAL(18, 2)")]
        [DataType(DataType.Currency)]
        [Range(1, 900000)]
        public decimal Salary { get; set; }

        public ICollection<Qualifications>? Qualifications { get; set; }

        [Display(Name = "Care Homes Name")]
        public int? CareHomesId { get; set; }

        [Display(Name = "Care Homes Name")]
        public CareHomes? CareHomes { get; set; }
    }
}