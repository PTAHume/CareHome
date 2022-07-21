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
        [Column(TypeName = "VARCHAR(256)")]
        [StringLength(256, MinimumLength = 2)]
        public string Forename { get; set; }

        [Column(TypeName = "VARCHAR(256)")]
        [StringLength(256, MinimumLength = 2)]
        public string MiddleNames { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(256)")]
        [StringLength(256, MinimumLength = 2)]
        public string LastName { get; set; }

        public CareHomes CareHomes { get; set; }

        public int? GenderTypesId { get; set; }

        public GenderTypes Gender { get; set; }

        public int? AddressDetailsId { get; set; }

        public AddressDetails AddressDetails { get; set; }

        public int? ContactDetailsId { get; set; }

        public ContactDetails ContactInfo { get; set; }

        public int? EthnicityGroupsId { get; set; }

        public EthnicityGroups Ethnicity { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-YYYY}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        public int? DepartmentId { get; set; }

        public Departments Department { get; set; }

        public int? JobTitlesId { get; set; }

        public JobTitles JobTitle { get; set; }

        [Column(TypeName = "DECIMAL(18, 2)")]
        [DataType(DataType.Currency)]
        [Range(1, 900000)]
        public decimal Salary { get; set; }
    }
}