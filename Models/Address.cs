using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LostandFoundAnimals.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        [DisplayName("Street name")]
        [StringLength(250, ErrorMessage = "Cannot be longer than 250 characters.")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Cannot be longer than 250 characters.")]
        public string City { get; set; }
        [DisplayName("Zipcode")]
        [StringLength(50, ErrorMessage = "Cannot be longer than 50 characters.")]
        public string ZipOrPostcode { get; set; }
        [Required]
        [DisplayName("State")]
        [StringLength(250, ErrorMessage = "Cannot be longer than 250 characters.")]
        public string StateProvinceCounty { get; set; }
        //public string CountryID { get; set; }
        public string OtherAddressDetails { get; set; }

        public Post Post { get; set; }
    }
}
