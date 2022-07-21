using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class Departments
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(256)")]
        [StringLength(256, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(MAX)")]
        [StringLength(8000, MinimumLength = 3)]
        public string Description { get; set; }

        public Staff Staff { get; set; }

        public ICollection<JobTitles> JobTitles { get; set; }
    }
}
