using System.ComponentModel.DataAnnotations;

namespace CareHome.Models
{
    public class ContactDetails
    {
        [Key]
        public int ContactDetailsId { get; set; }

        public string HomeNumber { get; set; }
        public string MobileNumber { get; set; }
        public string EMail { get; set; }
        public string PostCode { get; set; }
    }
}