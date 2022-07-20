using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffId { get; set; }

        [Required]
        public string Forename { get; set; }

        public string MiddleNames { get; set; }

        [Required]
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
        public DateTime DOB { get; set; }

        public int? DepartmentId { get; set; }

        public Departments Department { get; set; }

        public int? JobTitlesId { get; set; }

        public JobTitles JobTitle { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }
    }
}