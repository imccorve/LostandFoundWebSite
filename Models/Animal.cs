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
        //public Animal()
        //{
        //    this.Breeds = new HashSet<Breed>();
        //}
        [Required]
        public string AnimalName { get; set; }
        public int AnimalID { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public byte[] Image { get; set; }

        public int PostID { get; set; }
        public Post Post { get; set; }
        public int SpeciesID { get; set; }
        public Species Species { get; set; }
        public ICollection<Breed> Breeds { get; set; }


    }
}
