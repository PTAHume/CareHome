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
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(MAX)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal DefaultSalary { get; set; }

        public Departments Departments { get; set; }
    }
}