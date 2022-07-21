using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class CareHomes
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CareHomesId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(256)")]
        public string Name { get; set; }

        public int? AddressDetailsId { get; set; }

        public AddressDetails AddressDetails { get; set; }

        public int? ContactDetailsId { get; set; }

        public ContactDetails ContactInfo { get; set; }

        public ICollection<Staff> StaffMembers { get; set; }
    }
}
