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

        [Column(TypeName = "VARCHAR(32)")]
        public string HomeNumber { get; set; }

        [Column(TypeName = "VARCHAR(32)")]

        public string MobileNumber { get; set; }

        [Column(TypeName = "VARCHAR(256)")]
        public string EMail { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(16)")]
        public string PostCode { get; set; }

        public CareHomes CareHomes { get; set; }
    }
}
