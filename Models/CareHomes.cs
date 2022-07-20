using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class CareHomes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CareHomesId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        public int? AddressDetailsId { get; set; }

        public AddressDetails AddressDetails { get; set; }

        public int? ContactDetailsId { get; set; }

        public ContactDetails ContactInfo { get; set; }

        public ICollection<Staff> StaffMembers { get; set; }
    }
}
