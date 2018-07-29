using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace LostandFoundAnimals.Models
{
    public enum Gender
    {
        Male, Female
    }
    public class Animal
    {
        //Add animalname
        public int AnimalID { get; set; }
        //[Required]
        //[StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        //public string Name { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public byte[] Image { get; set; }
        //public int PostID { get; set; }


        //public int PostForeignKey { get; set; }
        public int PostID { get; set; }
        public Post Post { get; set; }
        public ICollection<Breed> Breeds { get; set; }
    }
}
