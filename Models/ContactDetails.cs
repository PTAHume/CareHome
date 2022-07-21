using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class ContactDetails
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactDetailsId { get; set; }

        [Required]
        public string ContactName { get; set; }

        [Display(Name = "Primary Contact (Home No)")]
        [Column(TypeName = "VARCHAR(32)")]
        [StringLength(32, MinimumLength = 3)]
        public string PrimaryNumber { get; set; }

        [Display(Name = "Secondary Contact (Mobile No)")]
        [Column(TypeName = "VARCHAR(32)")]
        [StringLength(32, MinimumLength = 3)]
        public string SecondaryNumber { get; set; }

        [Display(Name = "E-Mail")]
        [Column(TypeName = "VARCHAR(256)")]
        [StringLength(256, MinimumLength = 3)]
        public string EMail { get; set; }

        public CareHomes CareHomes { get; set; }
    }
}
