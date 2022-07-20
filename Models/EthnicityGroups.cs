using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class EthnicityGroups
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EthnicityGroupsId { get; set; }

        [Required]
        public string GroupName { get; set; }

        public Staff Staff { get; set; }

        public ICollection<EthnicityTypes> EthnicityClasses { get; set; }
    }
}