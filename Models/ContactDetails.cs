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
        [Display(Name = "Contact Name")]
        [Column(TypeName = "VARCHAR(256)")]
        [StringLength(256, MinimumLength = 3)]
        public string ContactName { get; set; }

        [Display(Name = "Primary Contact (Home No)")]
        [Column(TypeName = "VARCHAR(32)")]
        [StringLength(32, MinimumLength = 3)]
        [RegularExpression(@"^((\+44\s?\d{4}|\(?\d{5}\)?)\s?\d{6})|((\+44\s?|0)7\d{3}\s?\d{6})$", ErrorMessage = "Please enter valId UK number")]
        public string PrimaryNumber { get; set; }

        [Display(Name = "Secondary Contact (Mobile No)")]
        [Column(TypeName = "VARCHAR(32)")]
        [RegularExpression(@"^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$", ErrorMessage = "Please enter valId mobile number")]
        [StringLength(32, MinimumLength = 3)]
        public string? SecondaryNumber { get; set; }

        [Display(Name = "E-Mail")]
        [Column(TypeName = "VARCHAR(256)")]
        [StringLength(256, MinimumLength = 3)]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Please enter valId e-mail address")]
        public string? EMail { get; set; }

        public CareHomes? CareHomes { get; set; }
    }
}
