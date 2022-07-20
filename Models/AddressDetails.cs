using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class AddressDetails
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressDetailsId { get; set; }

        [Required]
        public string NumberStreetName { get; set; }

        public string Locality { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        public string PostCode { get; set; }

        public CareHomes CareHomes { get; set; }
    }
}
