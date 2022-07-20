using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class EthnicityTypes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EthnicityTypesId { get; set; }

        [Required]
        public string EthnicityName { get; set; }

        [Required]
        public EthnicityGroups EthnicityGroups { get; set; }
    }
}
