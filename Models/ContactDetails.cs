using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class ContactDetails
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactDetailsId { get; set; }

        [Required]
        public string ContactName { get; set; }

        public string HomeNumber { get; set; }

        public string MobileNumber { get; set; }

        public string EMail { get; set; }

        [Required]
        public string PostCode { get; set; }

        public CareHomes CareHomes { get; set; }
    }
}
