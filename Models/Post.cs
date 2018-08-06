using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LostandFoundAnimals.Models
{
    public enum LostOrFound
    {
        Lost, Found
    }
    public class Post
    {
        public int PostID { get; set; }
        // variable for post title
        //public int UserID { get; set; }
        //public int AnimalID { get; set; }
        [Required]
        [DisplayName("Details")]
        [StringLength(250, ErrorMessage = "Description cannot be longer than 250 characters.")]
        public string PostText { get; set; }
        public int? AddressID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        [DisplayName("Lost or Found")]
        public LostOrFound LostOrFound { get; set; }
        public bool Resolved { get; set; }

        //public User User { get; set; }
        public Animal Animal { get; set; }
        public Address Address { get; set; }
    }
}
