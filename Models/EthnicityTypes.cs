using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class EthnicityTypes
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EthnicityTypesId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(256)")]
        public string EthnicityName { get; set; }

        [Required]
        public EthnicityGroups EthnicityGroups { get; set; }
    }
}
