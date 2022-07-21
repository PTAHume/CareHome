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
        public string NumberStreetName { get; set; }

        [Column(TypeName = "VARCHAR(256)")]
        public string Locality { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(256)")]
        public string Town { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(16)")]
        public string PostCode { get; set; }

        public CareHomes CareHomes { get; set; }
    }
}
