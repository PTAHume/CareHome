using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class AddressDetails
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressDetailsId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(256)")]
        [StringLength(256, MinimumLength = 3)]
        [Display(Name = "House No & Street Name")]
        public string NumberStreetName { get; set; }

        [Column(TypeName = "VARCHAR(256)")]
        [StringLength(256, MinimumLength = 3)]
        public string? Locality { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(256)")]
        [StringLength(256, MinimumLength = 3)]
        public string Town { get; set; }

        [Required(ErrorMessage = "The Postcode field is required.")]
        [Column(TypeName = "VARCHAR(16)")]
        [StringLength(16, MinimumLength = 4)]
        [RegularExpression(@"^(([A-Z]{1,2}\d[A-Z\d]?|ASCN|STHL|TDCU|BBND|[BFS]IQQ|PCRN|TKCA) ?\d[A-Z]{2}|BFPO ?\d{1,4}|(KY\d|MSR|VG|AI)[ -]?\d{4}|[A-Z]{2} ?\d{2}|GE ?CX|GIR ?0A{2}|SAN ?TA1)$", ErrorMessage = "Please enter a valId UK post code in upper case")]
        public string Postcode { get; set; }

        public CareHomes? CareHomes { get; set; }
    }
}
