using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CareHome.Models
{
    public class Qualifications
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QualificationsId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(256)")]
        [StringLength(256, MinimumLength = 3)]
        [Display(Name = "Qualification Type")]
        public string QualificationType { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(256)")]
        [StringLength(256, MinimumLength = 3)]
        [Display(Name = "Qualification Name")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(256)")]
        [StringLength(256, MinimumLength = 3)]
        [Display(Name = "Grade Obtained")]
        public string Grade { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(256)")]
        [StringLength(256, MinimumLength = 3)]
        [Display(Name = "Institution Attended")]
        public string InstitutionalName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Obtained")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-YYYY}", ApplyFormatInEditMode = true)]
        public DateTime AttainmentDate { get; set; }

        public Staff Staff { get; set; }
    }
}
