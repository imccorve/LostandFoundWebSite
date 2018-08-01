using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LostandFoundAnimals.Models
{
    public class Breed
    {
        public int BreedID { get; set; }
        public int AnimalID { get; set; }
        [DisplayName("Breed")]
        [StringLength(50, ErrorMessage = "Breed cannot be longer than 50 characters.")]
        public string BreedName { get; set; }

        public Animal Animal { get; set; }
    }
}
