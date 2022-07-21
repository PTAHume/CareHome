using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class EthnicityGroups
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EthnicityGroupsId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(256)")]
        [StringLength(256, MinimumLength = 2)]
        public string GroupName { get; set; }

        public Staff Staff { get; set; }

        public ICollection<EthnicityTypes> EthnicityClasses { get; set; }
    }
}