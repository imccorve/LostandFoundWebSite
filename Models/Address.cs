using System;
namespace LostandFoundAnimals.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public string ZipOrPostcode { get; set; }
        public string StateProvinceCounty { get; set; }
        //public string CountryID { get; set; }
        public string OtherAddressDetails { get; set; }

        public Post Post { get; set; }
    }
}
