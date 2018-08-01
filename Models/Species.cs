using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LostandFoundAnimals.Models
{
    public class Species
    {
        [DisplayName("Type of animal")]
        public string SpeciesName { get; set; }
        public int SpeciesID { get; set; }

        public ICollection<Animal> Animals { get; set; }
    }
}
