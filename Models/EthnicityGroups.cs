using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class EthnicityGroups
    {
        [Key]
        public int EthnicityGroupsId { get; set; }

        public string GroupName { get; set; }

        [ForeignKey("EthnicityTypesId")]

        public List<EthnicityTypes>? EthnicityClasses { get; set; }
    }

    public class EthnicityTypes
    {
        [Key]
        public int EthnicityTypesId { get; set; }

        public int EthnicityName { get; set; }
    }
}