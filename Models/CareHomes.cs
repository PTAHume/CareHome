using System.ComponentModel.DataAnnotations;

namespace CareHome.Models
{
    public class CareHomes
    {
        [Key]
        public int CareHomesId { get; set; }

        public string Name { get; set; }

        public string ContactName { get; set; }

        public string ContactNumber { get; set; }
        public AddressDetails Address { get; set; }

        public ContactDetails ContactInfo { get; set; }
    }
}