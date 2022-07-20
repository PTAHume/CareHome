using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class GenderTypes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenderTypesId { get; set; }

        [Required]
        public string Gender { get; set; }

        public Staff Staff { get; set; }
    }
}