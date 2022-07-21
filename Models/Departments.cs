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
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(MAX)")]
        public string Description { get; set; }

        public Staff Staff { get; set; }

        public ICollection<JobTitles> JobTitles { get; set; }
    }
}
