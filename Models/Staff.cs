using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }

        public string Forename { get; set; }

        public string MiddleNames { get; set; }
        public string LastName { get; set; }

        [ForeignKey("GenderTypesId")]
        public ICollection<GenderTypes> Gender { get; set; }

        [ForeignKey("AddressDetailsId")]
        public AddressDetails Address { get; set; }

        [ForeignKey("EthnicityGroupsId")]
        public ICollection<EthnicityGroups> Ethnicity { get; set; }

        public DateOnly DOB { get; set; }

        [ForeignKey("JobTitlesId")]
        public JobTitles JobTitle { get; set; }

        public decimal Salary { get; set; }
    }

    public class GenderTypes
    {
        [Key]
        public int GenderTypesId { get; set; }

        public string Gender { get; set; }
    }
}