using System.ComponentModel.DataAnnotations;

namespace CareHome.Models
{
    public class AddressDetails
    {
        [Key]

        public int AddressDetailsId { get; set; }
        public string NumberStreetName { get; set; }
        public string? Locality { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
    }
}