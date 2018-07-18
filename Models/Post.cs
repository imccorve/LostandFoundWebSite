using System;
namespace LostandFoundAnimals.Models
{
    public class Post
    {
        public int PostID { get; set; }
        //public int UserID { get; set; }
        //public int AnimalID { get; set; }
        public string PostText { get; set; }
        public int AddressID { get; set; }
        public DateTime Date { get; set; }
        public string LostOrFound { get; set; }
        public bool Resolved { get; set; }

        //public User User { get; set; }
        public Animal Animal { get; set; }
        public Address Address { get; set; }
    }
}
