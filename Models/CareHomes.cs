using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareHome.Models
{
    public class CareHomes
    {
        [Key]
        public int CareHomesId { get; set; }

        public string Name { get; set; }

        public string ContactName { get; set; }

        public string ContactNumber { get; set; }

        [ForeignKey("AddressDetailsId")]

        public AddressDetails? Address { get; set; }

        [ForeignKey("ContactDetailsId")]

        public ContactDetails? ContactInfo { get; set; }
    }
}