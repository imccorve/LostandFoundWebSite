using System;
using System.Collections.Generic;

namespace LostandFoundAnimals.Models
{
    public class Animal
    {
        //Add animalname
        public int AnimalID { get; set; }
        public byte[] Image { get; set; }
        //public int PostID { get; set; }
        public string Gender { get; set; }


        //public int PostForeignKey { get; set; }
        public int PostID { get; set; }
        public Post Post { get; set; }
        public ICollection<Breed> Breeds { get; set; }
    }
}
