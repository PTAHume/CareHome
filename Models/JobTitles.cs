using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class JobTitles
    {
        [Key]
        public int JobTitlesId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal DefaultSalery { get; set; }

        [ForeignKey("DepartmentId")]
        public ICollection<Departments> Department { get; set; }
    }

    public class Departments
    {
        [Key]
        public int DepartmentId { get; set; }

        public string Name { get; set; }
    }
}