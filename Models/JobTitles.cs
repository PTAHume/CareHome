using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class JobTitles
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobTitlesId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(256)")]
        [StringLength(256, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(MAX)")]
        [StringLength(8000, MinimumLength = 2)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal DefaultSalary { get; set; }

        public Departments Departments { get; set; }
    }
}